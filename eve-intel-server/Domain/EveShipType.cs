using JetBrains.Annotations;

namespace eve_intel_server.Domain
{
    public class EveShipType
    {
        public virtual long Id { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }
    }
}
