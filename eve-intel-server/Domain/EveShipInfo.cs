using JetBrains.Annotations;

namespace eve_intel_server.Domain
{
    public class EveShipInfo
    {
        public virtual long Id { get; protected set; }

        [NotNull]
        public virtual string ShipName { get; protected set; }
        public virtual long ShipTypeId => ShipType.Id;
        public virtual int TechLevel { get; protected set; }
        public virtual long RaceId => Race.Id;

        [NotNull]
        public virtual EveShipType ShipType { get; protected set; }

        [NotNull]
        public virtual EveRace Race { get; protected set; }
    }
}
