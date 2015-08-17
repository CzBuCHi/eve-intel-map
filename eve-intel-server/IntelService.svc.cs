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
            Broadcast(callback => callback.LocalKosInfo(kosInfo), kosInfo.SenderId);
        }

        public void BroadcastKosPlayerInfo(KosPlayerInfo playerInfo) {
            Broadcast(callback => callback.KosPlayerInfo(playerInfo), playerInfo.SenderId);
        }

        private void OnlineClientsUpdate() {
            Broadcast(callback => callback.OnlineClientsUpdate(_Clients.Count));
        }

        private void Broadcast(Action<IIntelServiceCallback> callback, Guid? senderId = null) {
            List<Guid> deadClients = new List<Guid>();
            lock (_Locker) {
                foreach (KeyValuePair<Guid, IIntelServiceCallback> client in _Clients) {
                    if (client.Key != senderId) {
                        try {
                            callback(client.Value);
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
    }
}
