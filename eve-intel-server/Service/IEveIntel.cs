using System;
using System.ServiceModel;
using JetBrains.Annotations;

namespace eve_intel_server.Service
{
    [ServiceContract(CallbackContract = typeof(IEveIntelCallback))]
    public interface IEveIntel
    {
        /// <summary>
        /// Client connection
        /// </summary>
        /// <param name="keyId">EVE key id</param>
        /// <param name="vCode">EVE key verification code</param>
        /// <returns>Client id used by all other requests-or-null if kos character detected.</returns>
        [OperationContract(IsOneWay = false)]
        Guid? Connect(long keyId, [NotNull] string vCode);

        /// <summary>
        /// Client disconnection
        /// </summary>
        /// <param name="clientId">Client id</param>
        [OperationContract(IsOneWay = true)]
        void Disconnect(Guid clientId);
    }

    public interface IEveIntelCallback
    {
        /// <summary>
        /// Server notification about client count change
        /// </summary>
        /// <param name="clientCount">Actual client count</param>
        [OperationContract(IsOneWay = true)]
        void ClientCountUpdate(int clientCount);
    }
}
