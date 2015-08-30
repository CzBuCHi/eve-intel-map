using System.Configuration;
using System.Data.Entity;
using System.Data.SQLite;

namespace eve_intel_map.Model
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(new SQLiteConnection(ConfigurationManager.ConnectionStrings["eve-intel-map"].ConnectionString), true) {
        }

        public DbSet<EveMapRegion> Regions { get; set; }
        public DbSet<EveMapSolarsystem> SolarSystems { get; set; }
        public DbSet<EveMapSolarsystemJump> SolarSystemJumps { get; set; }
    }

    public static class DbHelper
    {
        private static DataContext _DataContext;
        public static DataContext DataContext => _DataContext ?? (_DataContext = new DataContext());
        public static bool HasDataContext => _DataContext != null;
    }
}
