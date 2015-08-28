using System;

namespace eve_intel_server.Domain
{
    public class EvePlayerInfo
    {
        public virtual long Id { get; set; }
        public virtual long PlayerId { get; set; }
        public virtual string PlayerName { get; set; }
        public virtual bool IsKos { get; set; }
        public virtual long? ShipInfoId => ShipInfo?.Id;
        public virtual DateTime ShipInfoTime { get; set; }
        public virtual bool IsShipInfoConfirmed { get; set; }
        public virtual long? SolarsystemId => Solarsystem?.Id;
        public virtual DateTime SolarsystemTime { get; set; }
        public virtual EveShipInfo ShipInfo { get; set; }
        public virtual EveMapSolarsystem Solarsystem { get; set; }
    }
}

