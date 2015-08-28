using JetBrains.Annotations;

namespace eve_intel_server.Domain
{
    public class EveMapSolarsystemJump
    {
        public virtual long FromSolarsystemId => FromSolarsystem.Id;
        public virtual long ToSolarsystemId => ToSolarsystem.Id;
        public virtual long FromRegionId => FromRegion.Id;
        public virtual long ToRegionId => ToRegion.Id;

        [NotNull]
        public virtual EveMapSolarsystem FromSolarsystem { get; set; }

        [NotNull]
        public virtual EveMapSolarsystem ToSolarsystem { get; set; }

        [NotNull]
        public virtual EveMapRegion FromRegion { get; set; }

        [NotNull]
        public virtual EveMapRegion ToRegion { get; set; }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((EveMapSolarsystemJump) obj);
        }

        protected bool Equals(EveMapSolarsystemJump other) {
            return Equals(FromSolarsystem, other.FromSolarsystem) && Equals(ToSolarsystem, other.ToSolarsystem);
        }

        public override int GetHashCode() {
            unchecked {                
                // ReSharper disable NonReadonlyMemberInGetHashCode
                return (FromSolarsystem.GetHashCode()*397) ^ ToSolarsystem.GetHashCode();
                // ReSharper restore NonReadonlyMemberInGetHashCode
            }
        }
    }
}
