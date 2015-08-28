namespace eve_intel_server.Domain
{
    public class EveShipInfo
    {
        public virtual long Id { get; set; }
        public virtual string ShipName { get; set; }
        public virtual long ShipTypeId => ShipType.Id;
        public virtual int TechLevel { get; set; }
        public virtual long RaceId => Race.Id;
        public virtual EveShipType ShipType { get; set; }
        public virtual EveRace Race { get; set; }
    }
}