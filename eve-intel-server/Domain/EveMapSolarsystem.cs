using JetBrains.Annotations;

namespace eve_intel_server.Domain
{
    public class EveMapSolarsystem
    {
        public virtual long Id { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }
        public virtual long RegionId => Region.Id;

        [NotNull]
        public virtual EveMapRegion Region { get; protected set; }
    }
}
