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
    }

    public interface IIntelServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void LocalKosInfo(LocalKosInfo kosInfo);

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
}
