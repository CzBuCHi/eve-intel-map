using System;
using System.Linq;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Linq;

namespace eve_intel_server.Domain
{
    public class EvePlayerInfo
    {
        public virtual long Id { get; set; }

        [NotNull]
        public virtual string PlayerName { get; set; }
        public virtual bool IsKos { get; set; }
        public virtual long? ShipInfoId => ShipInfo?.Id;
        public virtual DateTime? ShipInfoTime { get; set; }
        public virtual bool IsShipInfoConfirmed { get; set; }
        public virtual long? SolarsystemId => Solarsystem?.Id;
        public virtual DateTime? SolarsystemTime { get; set; }

        [CanBeNull]
        public virtual EveShipInfo ShipInfo { get; set; }

        [CanBeNull]
        public virtual EveMapSolarsystem Solarsystem { get; set; }

        public virtual void SetShipInfoId(long? value, ISession session) {
            ShipInfo = value == null ? null : session.Query<EveShipInfo>().First(o => o.Id == value.Value);
        }

        public virtual void SetSolarsystemId(long? value, ISession session) {
            Solarsystem = value == null ? null : session.Query<EveMapSolarsystem>().First(o => o.Id == value.Value);
        }
    }
}
