using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using eve_intel_server.CvaKos;
using eve_intel_server.Domain;
using EveAI.Live;
using EveAI.Live.Account;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Linq;

namespace eve_intel_server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EveIntel : IEveIntel
    {
        private static readonly Dictionary<Guid, ClientInfo> _Clients = new Dictionary<Guid, ClientInfo>();
        private static readonly Dictionary<int, Guid> _ClientHashes = new Dictionary<int, Guid>();
        private static readonly object _ClientsLock = new object();

        #region Helpers

        [NotNull]
        private static CvaCharacterInfo[] GetCvaCharacterInfos([NotNull] AccountEntry[] characters) {
            long[] characterIds = characters.Select(o => o.CharacterID).ToArray();

            CvaCharacterInfo[] result = new CvaCharacterInfo[characters.Length];
            using (ISession session = DataHelper.OpenSession()) {
                // try read info from local db
                IQueryable<CvaCharacterInfo> q = from o in session.Query<CvaCharacterInfo>()
                                                 where characterIds.Contains(o.EveId)
                                                 select o;
                int cached = 0;
                foreach (CvaCharacterInfo item in q) {
                    int index = Array.IndexOf(characterIds, item.EveId);
                    result[index] = item;
                    ++cached;
                }

                if (cached == result.Length) {
                    return result;
                }

                // download infos not stored in local db and save them
                using (ITransaction trans = session.BeginTransaction()) {
                    for (int i = 0; i < result.Length; i++) {
                        if (result[i] == null) {
                            CvaCharacterInfo character = CvaClient.GetCharacterInfo(characters[i].CharacterID, characters[i].Name);
                            if (character.Corp.Alliance != null) {
                                session.SaveOrUpdate(character.Corp.Alliance);
                            }
                            session.SaveOrUpdate(character.Corp);
                            session.Save(character);
                            result[i] = character;
                        }
                    }
                    trans.Commit();
                }
            }
            return result;
        }

        #endregion

        private struct ClientInfo
        {
            [NotNull]
            public IEveIntelCallback Callback { get; set; }

            public int Hash { get; set; }
        }

        #region Broadcasting

        private static readonly Queue<BroadcastMessage> _BroadcastMessages = new Queue<BroadcastMessage>();
        private static Timer _BroadcastDelayTimer;
        private static readonly object _BroadcastDelayTimerLock = new object();

        private static void Broadcast(BroadcastMessage message) {
            List<Guid> inactive = new List<Guid>();
            bool doCLientCountUpdate = false;

            lock (_ClientsLock) {
                IEnumerable<KeyValuePair<Guid, ClientInfo>> clients = _Clients.AsEnumerable();
                if (message.Clients != null) {
                    clients = from pair in clients
                              join clientId in message.Clients on pair.Key equals clientId
                              select pair;
                }

                foreach (KeyValuePair<Guid, ClientInfo> pair in clients.ToArray()) {
                    try {
                        message.Action(pair.Value.Callback);
                    } catch {
                        inactive.Add(pair.Key);
                    }
                }

                if (inactive.Count > 0) {
                    foreach (Guid id in inactive) {
                        _Clients.Remove(id);
                    }
                    if (_Clients.Count > 0) {
                        doCLientCountUpdate = true;
                    }
                }
            }

            if (doCLientCountUpdate) {
                DelayedBroadcast(client => { client.ClientCountUpdate(_Clients.Count); });
            }
        }

        private static void DelayedBroadcastExec(object state) {
            while (_BroadcastMessages.Count > 0) {
                BroadcastMessage message = _BroadcastMessages.Dequeue();
                Broadcast(message);
            }

            lock (_BroadcastDelayTimerLock) {
                _BroadcastDelayTimer = null;
            }
        }

        private static void DelayedBroadcast([NotNull] Action<IEveIntelCallback> action, Guid[] clients = null) {
            _BroadcastMessages.Enqueue(new BroadcastMessage {
                Action = action,
                Clients = clients
            });

            lock (_BroadcastDelayTimerLock) {
                if (_BroadcastDelayTimer == null) {
                    _BroadcastDelayTimer = new Timer(DelayedBroadcastExec, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                }
            }
        }

        private struct BroadcastMessage
        {
            [NotNull]
            public Action<IEveIntelCallback> Action { get; set; }

            [CanBeNull]
            public Guid[] Clients { get; set; }
        }

        #endregion

        #region Implementation of IEveIntel

        public Guid? Connect(long keyId, string vCode) {
            // check for connection with same keyId & vCode
            int hashCode = new {keyId, vCode}.GetHashCode();
            lock (_ClientsLock) {
                Guid clientId;
                if (_ClientHashes.TryGetValue(hashCode, out clientId)) {
                    // inform first client and disconnect him 
                    DelayedBroadcast(client => {
                        client.SecondConnection();
                        lock (_ClientsLock) {
                            _Clients.Remove(clientId);
                        }
                    }, new[] {clientId});
                    DelayedBroadcast(client => { client.ClientCountUpdate(_Clients.Count); });
                    return null;
                }
            }

            // get client callback
            IEveIntelCallback callback;
            try {
                callback = OperationContext.Current.GetCallbackChannel<IEveIntelCallback>();
            } catch {
                // invalid client
                return null;
            }

            // connect to eve api and get all player character names
            AccountEntry[] characters;
            try {
                EveApi eveApi = new EveApi(keyId, vCode);
                characters = eveApi.GetAccountEntries().ToArray();
            } catch (Exception) {
                // invalid key/vCode
                return null;
            }

            // kos check against all player characters
            CvaCharacterInfo[] characterInfos = GetCvaCharacterInfos(characters);
            if (characterInfos.Any(o => o.Kos)) {
                return null;
            }

            // generate client id
            Guid result = Guid.NewGuid();
            lock (_ClientsLock) {
                _Clients.Add(result, new ClientInfo {
                    Callback = callback,
                    Hash = hashCode
                });
                _ClientHashes.Add(hashCode, result);
            }

            DelayedBroadcast(client => { client.ClientCountUpdate(_Clients.Count); });
            return result;
        }

        public void Disconnect(Guid clientId) {
            lock (_ClientsLock) {
                ClientInfo clientInfo;
                if (!_Clients.TryGetValue(clientId, out clientInfo)) {
                    return;
                }
                _Clients.Remove(clientId);
                _ClientHashes.Remove(clientInfo.Hash);
            }
            DelayedBroadcast(client => { client.ClientCountUpdate(_Clients.Count); });
        }

        #endregion
    }
}
