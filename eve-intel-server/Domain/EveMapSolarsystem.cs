namespace eve_intel_server.Domain
{
    public class EveMapSolarsystem
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual long? RegionId => Region?.Id;

        public virtual EveMapRegion Region { get; set; }
    }
}