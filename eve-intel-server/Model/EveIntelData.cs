using System;
using System.Linq;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Linq;

namespace eve_intel_server.Model
{
    public class EveIntelData
    {
        public virtual long Id { get; set; }
        public virtual long CharacterId => Character.Id;

        [NotNull]
        public virtual EveIntelCharacterInfo Character { get; set; }

        public virtual long? ShipInfoId => ShipInfo?.Id;

        [CanBeNull]
        public virtual EveShipInfo ShipInfo { get; set; }

        public virtual DateTime? ShipInfoDate { get; set; }
        public virtual bool ShipInfoConfirmed { get; set; }
        public virtual long Solarsystem { get; set; }
        public virtual DateTime? SolarsystemDate { get; set; }

        public virtual void SetCharacterId(long value, ISession session) {
            Character = session.Query<EveIntelCharacterInfo>().First(o => o.Id == value);
        }

        public virtual void SetShipInfoId(long? value, ISession session) {
            ShipInfo = value == null ? null : session.Query<EveShipInfo>().First(o => o.Id == value.Value);
        }
    }
}
