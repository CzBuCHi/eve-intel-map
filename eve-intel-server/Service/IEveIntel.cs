using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml;
using eve_intel_server.Model;
using JetBrains.Annotations;

namespace eve_intel_server.Service
{
    [ServiceContract(CallbackContract = typeof (IEveIntelCallback))]
    [ServiceKnownType(typeof (EveIntelCharacterInfo))]
    [ServiceKnownType(typeof (EveIntelCorporationInfo))]
    [ServiceKnownType(typeof (EveIntelAllianceInfo))]
    public interface IEveIntel
    {
        /// <summary>
        ///     Client connection
        /// </summary>
        /// <param name="keyId">EVE key id</param>
        /// <param name="vCode">EVE key verification code</param>
        /// <returns>Client id used by all other requests-or-null if kos character detected.</returns>
        [OperationContract(IsOneWay = false)]
        Guid? Connect(long keyId, [NotNull] string vCode);

        /// <summary>
        ///     Client disconnection
        /// </summary>
        /// <param name="clientId">Client id</param>
        [OperationContract(IsOneWay = true)]
        void Disconnect(Guid clientId);

        /// <summary>
        ///     Information about local characters from client
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <param name="currentSystem">Client local system</param>
        /// <param name="characterNames">List of characters in local</param>
        [OperationContract(IsOneWay = true)]
        void UpdateLocal(Guid clientId, long currentSystem, [NotNull] string[] characterNames);
    }

    public interface IEveIntelCallback
    {
        /// <summary>
        ///     Server notification about client count change
        /// </summary>
        /// <param name="clientCount">Actual client count</param>
        [OperationContract(IsOneWay = true)]
        void ClientCountUpdate(int clientCount);

        /// <summary>
        ///     Server informs client, that another client was trying to connect with save keyId and vCode
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SecondConnection();

        /// <summary>
        ///     Server informs clients about local characters
        /// </summary>
        /// <param name="solarsystemId">Client local system</param>
        /// <param name="characters">INfo about characters in local</param>
        [OperationContract(IsOneWay = true)]
        void ClientLocalUpdate(long solarsystemId, EveIntelCharacterInfo[] characters);
    }
}
