using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using eve_intel_server.CvaKos;

using EveAI.Live;
using JetBrains.Annotations;
using log4net;

namespace eve_intel_server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EveIntel : IEveIntel
    {
        private static readonly Dictionary<Guid, ClientInfo> _Clients = new Dictionary<Guid, ClientInfo>();
        private static readonly Dictionary<int, Guid> _ClientHashes = new Dictionary<int, Guid>();
        private static readonly object _ClientsLock = new object();
        private static readonly ILog _Logger;

        static EveIntel() {
            _Logger = LogManager.GetLogger(typeof (EveIntel));
        }

        #region Helpers

        [NotNull]
        private static EveIntelCharacterInfo[] GetEveIntelCharacterInfos([NotNull] Dictionary<long, string> characters) {
            _Logger.Debug("GetEveIntelCharacterInfos: '" + string.Join("', '", characters.Values) + "'");
            return null;
            //long[] characterIds = characters.Keys.ToArray();
            //Dictionary<long, CvaCharacterInfo> result = new Dictionary<long, CvaCharacterInfo>();
            //using (ISession session = DataContext.OpenSession()) {
            //    // try read info from local db
            //    IQueryable<CvaCharacterInfo> q = from o in session.Query<CvaCharacterInfo>()
            //                                     where characterIds.Contains(o.EveId)
            //                                     select o;
            //    int cached = 0;
            //    foreach (CvaCharacterInfo item in q) {
            //        result[item.EveId] = item;
            //        ++cached;
            //    }

            //    if (cached == characters.Count) {
            //        return result.Values.Select(Convert.GetEveIntelCharacterInfo).ToArray();
            //    }

            //    // download infos not stored in local db and save them
            //    using (ITransaction trans = session.BeginTransaction()) {
            //        foreach (KeyValuePair<long, string> pair in characters) {
            //            if (result.ContainsKey(pair.Key)) {
            //                continue;
            //            }

            //            CvaCharacterInfo character = CvaClient.GetCharacterInfo(pair.Key, pair.Value);
            //            if (character != null) {
            //                if (character.Corp.Alliance != null) {
            //                    session.SaveOrUpdate(character.Corp.Alliance);
            //                }
            //                session.SaveOrUpdate(character.Corp);
            //                session.Save(character);
            //                result.Add(character.EveId, character);
            //            }
            //        }
            //        trans.Commit();
            //    }
            //}
            //return result.Values.Select(Convert.GetEveIntelCharacterInfo).ToArray();
        }

        #endregion

        private struct ClientInfo
        {
            [NotNull]
            public IEveIntelCallback Callback { get; set; }

            public long KeyId { get; set; }
            public string VCode { get; set; }
            public int HashCode { get; set; }
        }

        #region Broadcasting

        private static readonly Queue<BroadcastMessage> _BroadcastMessages = new Queue<BroadcastMessage>();
        private static Timer _BroadcastDelayTimer;
        private static readonly object _BroadcastDelayTimerLock = new object();

        private static void Broadcast(BroadcastMessage message) {
            _Logger.Debug("Broadcast: '" + message.DebugInfo + "'");
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
                    } catch (Exception exc) {
                        _Logger.Error("Broadcast error", exc);
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
                DelayedBroadcast(new BroadcastMessage {
                    Action = client => { client.ClientCountUpdate(_Clients.Count); },
                    DebugInfo = "ClientCountUpdate"
                });
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

        private static void DelayedBroadcast(BroadcastMessage message) {
            _Logger.Debug("DelayedBroadcast '" + message.DebugInfo + "'");
            _BroadcastMessages.Enqueue(message);

            lock (_BroadcastDelayTimerLock) {
                if (_BroadcastDelayTimer == null) {
                    _BroadcastDelayTimer = new Timer(DelayedBroadcastExec, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                }
            }
        }

        [DebuggerDisplay("{DebugInfo,nq}")]
        private struct BroadcastMessage
        {
            [NotNull]
            public string DebugInfo { get; set; }

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
            //lock (_ClientsLock) {
            //    Guid clientId;
            //    if (_ClientHashes.TryGetValue(hashCode, out clientId)) {
            //        // inform first client and disconnect him 
            //        DelayedBroadcast(new BroadcastMessage {
            //            Action = client => {
            //                client.SecondConnection();
            //                lock (_ClientsLock) {
            //                    _Clients.Remove(clientId);
            //                }
            //            },
            //            DebugInfo = "SecondConnection",
            //            Clients = new[] { clientId }
            //        });
            //        DelayedBroadcast(new BroadcastMessage {
            //            Action = client => { client.ClientCountUpdate(_Clients.Count); },
            //            DebugInfo = "ClientCountUpdate"
            //        });
            //        _Logger.Info("Dupliacate connection: " + keyId);
            //        return null;
            //    }
            //}

            // get client callback
            IEveIntelCallback callback;
            try {
                callback = OperationContext.Current.GetCallbackChannel<IEveIntelCallback>();
            } catch (Exception exc) {
                _Logger.Error("Connect: get IEveIntelCallback: ", exc);
                // invalid client
                return null;
            }

            // connect to eve api and get all player character names
            Dictionary<long, string> characters;
            try {
                EveApi eveApi = new EveApi(keyId, vCode);
                characters = eveApi.GetAccountEntries().ToDictionary(o => o.CharacterID, o => o.Name);
            } catch (Exception) {
                // invalid key/vCode
                _Logger.Warn("Connect: invalid key/vCode: " + keyId + ", '" + vCode + "'");
                return null;
            }

            if (characters.Count == 0) {
                _Logger.Warn("Connect: invalid key/vCode (no characters): " + keyId + ", '" + vCode + "'");
                return null;
            }

            // kos check against all player characters
            EveIntelCharacterInfo[] characterInfos = GetEveIntelCharacterInfos(characters);
            EveIntelCharacterInfo[] kosInfos = characterInfos.Where(o => o.Kos).ToArray();
            if (kosInfos.Length > 0) {
                _Logger.Warn("Connect: kos characters: '" + string.Join("', '", kosInfos.Select(o => o.Label)));
                return null;
            }

            // generate client id
            Guid result = Guid.NewGuid();
            lock (_ClientsLock) {
                _Clients.Add(result, new ClientInfo {
                    Callback = callback,
                    KeyId = keyId,
                    VCode = vCode,
                    HashCode = hashCode
                });

                // DEBUG CODE
                if (!_ClientHashes.ContainsKey(hashCode)) {
                    _ClientHashes.Add(hashCode, result);
                }
            }

            DelayedBroadcast(new BroadcastMessage {
                Action = client => { client.ClientCountUpdate(_Clients.Count); },
                DebugInfo = "ClientCountUpdate"
            });

            _Logger.Info("Connect: " + result + " (" + characterInfos[0].Label + ")");
            return result;
        }

        public void Disconnect(Guid clientId) {
            _Logger.Info("Disconnect: " + clientId);
            lock (_ClientsLock) {
                ClientInfo clientInfo;
                if (!_Clients.TryGetValue(clientId, out clientInfo)) {
                    return;
                }
                _Clients.Remove(clientId);
                _ClientHashes.Remove(clientInfo.HashCode);
            }
            DelayedBroadcast(new BroadcastMessage {
                Action = client => { client.ClientCountUpdate(_Clients.Count); },
                DebugInfo = "ClientCountUpdate"
            });
        }

        public void UpdateLocal(Guid clientId, long currentSystem, string[] characterNames) {
            _Logger.Info("UpdateLocal: " + clientId);
            ClientInfo clientInfo;
            lock (_ClientsLock) {
                if (!_Clients.TryGetValue(clientId, out clientInfo)) {
                    return;
                }
            }

            EveApi eveApi = new EveApi(clientInfo.KeyId, clientInfo.VCode);
            Dictionary<long, string> characters = eveApi.GetCharacterIDLookup(characterNames.ToList()).ToDictionary(o => o.Value, o => o.Key);
            EveIntelCharacterInfo[] characterInfos = GetEveIntelCharacterInfos(characters);

            DelayedBroadcast(new BroadcastMessage {
                Action = client => { client.ClientLocalUpdate(currentSystem, characterInfos); },
                DebugInfo = "ClientLocalUpdate"
            });
        }

        #endregion
    }
}
