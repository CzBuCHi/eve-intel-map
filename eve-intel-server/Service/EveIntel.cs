using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using eve_intel_server.CvaKos;
using EveAI.Live;
using JetBrains.Annotations;

namespace eve_intel_server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EveIntel : IEveIntel
    {
        private static readonly Dictionary<Guid, IEveIntelCallback> _Clients = new Dictionary<Guid, IEveIntelCallback>();
        private static readonly object _ClientsLock = new object();
        private static readonly Queue<Action<IEveIntelCallback>> _BroadcastActions = new Queue<Action<IEveIntelCallback>>();
        private static Timer _BroadcastDelayTimer;
        private static readonly object _BroadcastDelayTimerLock = new object();

        private static void Broadcast([NotNull] Action<IEveIntelCallback> callback) {
            List<Guid> inactive = new List<Guid>();
            bool doCLientCountUpdate = false;

            lock (_ClientsLock) {
                foreach (KeyValuePair<Guid, IEveIntelCallback> pair in _Clients) {
                    try {
                        callback(pair.Value);
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
            while (_BroadcastActions.Count > 0) {
                Action<IEveIntelCallback> action = _BroadcastActions.Dequeue();
                Broadcast(action);
            }

            lock (_BroadcastDelayTimerLock) {
                _BroadcastDelayTimer = null;
            }
        }

        private static void DelayedBroadcast([NotNull] Action<IEveIntelCallback> callback) {
            _BroadcastActions.Enqueue(callback);

            lock (_BroadcastDelayTimerLock) {
                if (_BroadcastDelayTimer == null) {
                    _BroadcastDelayTimer = new Timer(DelayedBroadcastExec, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                }
            }
        }

        #region Implementation of IEveIntel

        public Guid? Connect(long keyId, string vCode) {
            // get client callback
            IEveIntelCallback callback;
            try {
                callback = OperationContext.Current.GetCallbackChannel<IEveIntelCallback>();
            } catch {
                // invalid client
                return null;
            }

            // TODO: DEBUG CODE
            if (keyId == 0) {
                return null;
            }
            if (!string.IsNullOrEmpty(vCode)) {

                // connect to eve api and get all player character names
                string[] characterNames;
                try {
                    EveApi eveApi = new EveApi(keyId, vCode);
                    characterNames = eveApi.GetAccountEntries().Select(o => o.Name).ToArray();
                } catch (Exception) {
                    // invalid key/vCode
                    return null;
                }

                // kos check against all player characters
                CvaCharacterInfo[] characterInfos = CvaClient.GetCvaCharacterInfos(characterNames);
                if (characterInfos.Any(o => o.Kos)) {
                    return null;
                }
            }

            // generate client id
            Guid result = Guid.NewGuid();
            lock (_ClientsLock) {
                _Clients.Add(result, callback);
            }
                        
            DelayedBroadcast(client => { client.ClientCountUpdate(_Clients.Count); });
            return result;
        }

        public void Disconnect(Guid clientId) {
            lock (_ClientsLock) {
                _Clients.Remove(clientId);
            }
            DelayedBroadcast(client => { client.ClientCountUpdate(_Clients.Count); });
        }

        #endregion
    }
}
