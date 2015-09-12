using System;
using System.ServiceModel;
using JetBrains.Annotations;

namespace eve_intel_server.Service
{
    [ServiceContract(CallbackContract = typeof (IEveIntelCallback))]
    [ServiceKnownType(typeof (EveIntelCharacterInfo))]
    public interface IEveIntel
    {
        /// <summary>
        ///     Client connection
        /// </summary>
        /// <param name="keyId">EVE key id</param>
        /// <param name="vCode">EVE key verification code</param>
        /// <param name="solarsystemID">Client local system (kos player will give intel on himself whent trying to connect)</param>
        /// <returns>Client id used by all other requests-or-null if kos character detected.</returns>
        [OperationContract(IsOneWay = false)]
        Guid? Connect(long keyId, [NotNull] string vCode, long solarsystemID);

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
        /// <param name="solarsystemID">Client local system</param>
        /// <param name="characterNames">List of characters in local</param>
        [OperationContract(IsOneWay = true)]
        void UpdateLocal(Guid clientId, long solarsystemID, [NotNull] string[] characterNames);

        /// <summary>
        /// Client is asking server for ALL known characters
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <returns>Info about all known kos characters</returns>
        [OperationContract(IsOneWay = false)]
        EveIntelCharacterInfo[] ClientGlobalUpdate(Guid clientId);
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
        /// <param name="solarsystemID">ID of system from with second connection was originated</param>
        [OperationContract(IsOneWay = true)]
        void SecondConnection(long solarsystemID);

        /// <summary>
        ///     Server informs clients about local characters
        /// </summary>
        /// <param name="solarsystemId">Client local system</param>
        /// <param name="characters">Info about characters in local</param>
        [OperationContract(IsOneWay = true)]
        void ClientIntelUpdate(EveIntelCharacterInfo[] characters);
    }
}
