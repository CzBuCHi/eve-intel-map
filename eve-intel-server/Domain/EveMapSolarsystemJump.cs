using JetBrains.Annotations;

namespace eve_intel_server.Domain
{
    public class EveMapSolarsystemJump
    {
        public virtual long FromSolarsystemId => FromSolarsystem.Id;
        public virtual long ToSolarsystemId => ToSolarsystem.Id;

        [NotNull]
        public virtual EveMapSolarsystem FromSolarsystem { get; protected set; }

        [NotNull]
        public virtual EveMapSolarsystem ToSolarsystem { get; protected set; }

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

        protected bool Equals([NotNull] EveMapSolarsystemJump other) {
            return FromSolarsystem.Equals(other.FromSolarsystem) && ToSolarsystem.Equals(other.ToSolarsystem);
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
