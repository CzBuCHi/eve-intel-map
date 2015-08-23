using System.Configuration;
using System.Data.Entity;
using System.Data.SQLite;

namespace eve_intel_map.model
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(new SQLiteConnection(ConfigurationManager.ConnectionStrings["eve-log-watcher"].ConnectionString), true) {
        }

        // ReSharper disable UnusedMember.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public DbSet<Region> Regions { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<SolarSystemJump> SolarSystemJumps { get; set; }

        public DbSet<Race> Races { get; set; }
        public DbSet<ShipName> ShipNames { get; set; }
        public DbSet<ShipType> ShipTypes { get; set; }



        // ReSharper restore UnusedMember.Global
        // ReSharper restore UnusedAutoPropertyAccessor.Global
    }
}
