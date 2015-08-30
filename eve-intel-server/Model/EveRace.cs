using JetBrains.Annotations;

namespace eve_intel_server.Model
{
    public class EveRace
    {
        public virtual long Id { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }
    }
}
