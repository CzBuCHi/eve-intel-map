using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace eve_intel_server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class IntelService : IIntelService
    {
        private static readonly Dictionary<Guid, IIntelServiceCallback> _Clients = new Dictionary<Guid, IIntelServiceCallback>();
        private static readonly object _Locker = new object();

        public ConnectionInfo Connect() {
            try {
                IIntelServiceCallback callback = OperationContext.Current.GetCallbackChannel<IIntelServiceCallback>();

                Guid clientId;
                long onlineClients;
                lock (_Locker) {
                    do {
                        clientId = Guid.NewGuid();
                    } while (_Clients.ContainsKey(clientId));

                    _Clients[clientId] = callback;
                    onlineClients = _Clients.Count;
                }

                return new ConnectionInfo {
                    ClientId = clientId,
                    OnlineClients = onlineClients
                };
            } catch {
                return null;
            }
        }

        public void BroadcastLocalKos(LocalKosInfo kosInfo) {
            List<Guid> deadClients = new List<Guid>();
            lock (_Locker) {                
                foreach (KeyValuePair<Guid, IIntelServiceCallback> client in _Clients) {
                    if (client.Key != kosInfo.SenderId) {
                        try {
                            client.Value.LocalKosInfo(kosInfo);
                        } catch {
                            deadClients.Add(client.Key);
                        }
                    }
                }

                if (deadClients.Count > 0) {
                    foreach (Guid client in deadClients) {
                        _Clients.Remove(client);
                    }
                    deadClients.Clear();
                }
            }

            if (deadClients.Count > 0) {
                OnlineClientsUpdate();
            }
        }

        // Notify alive clients about deaths ...
        private static void OnlineClientsUpdate() {
            while (true) {
                List<Guid> deadClients = new List<Guid>();
                lock (_Locker) {
                    foreach (KeyValuePair<Guid, IIntelServiceCallback> client in _Clients) {
                        try {
                            client.Value.OnlineClientsUpdate(_Clients.Count);
                        } catch {
                            deadClients.Add(client.Key);
                        }
                    }
                    // in meanwhile some clients may die ...
                    if (deadClients.Count > 0) {
                        foreach (Guid client in deadClients) {
                            _Clients.Remove(client);
                        }
                    }
                }

                // ... if that hapends notify rest again ...
                if (deadClients.Count == 0) {
                    break;
                }
            }
        }
    }
}
