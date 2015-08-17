using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eve_intel_server
{
    [ServiceContract(CallbackContract = typeof (IIntelServiceCallback))]
    public interface IIntelService
    {
        [OperationContract(IsOneWay = false)]
        ConnectionInfo Connect();

        [OperationContract(IsOneWay = true)]
        void BroadcastLocalKos(LocalKosInfo kosInfo);

        [OperationContract(IsOneWay = true)]
        void BroadcastKosPlayerInfo(KosPlayerInfo playerInfo);
    }

    public interface IIntelServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void LocalKosInfo(LocalKosInfo kosInfo);

        [OperationContract(IsOneWay = true)]
        void KosPlayerInfo(KosPlayerInfo playerInfo);

        [OperationContract(IsOneWay = true)]
        void OnlineClientsUpdate(long onlineClients);
    }

    [DataContract]
    public class ConnectionInfo
    {
        [DataMember]
        public Guid ClientId { get; set; }

        [DataMember]
        public long OnlineClients { get; set; }
    }

    [DataContract]
    public class LocalKosInfo
    {
        [DataMember]
        public Guid SenderId { get; set; }

        [DataMember]
        public long SystemId { get; set; }

        [DataMember]
        public string[] PilotNames { get; set; }
    }

    [DataContract]
    public class KosPlayerInfo
    {
        [DataMember]
        public Guid SenderId { get; set; }

        [DataMember]
        public string PilotName { get; set; }

        [DataMember]
        public string PilotShip { get; set; }

        [DataMember]
        public DateTime PilotShipTime { get; set; }

        [DataMember]
        public long LastKnownSystem { get; set; }

        [DataMember]
        public DateTime LastKnownSystemTime { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
