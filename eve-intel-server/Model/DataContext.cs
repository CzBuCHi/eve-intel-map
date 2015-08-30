using NHibernate;
using NHibernate.Cfg;

namespace eve_intel_server.Model
{
    public static class DataContext
    {
        private static readonly ISessionFactory _SessionFactory;

        static DataContext() {
            _SessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession OpenSession() {
            return _SessionFactory.OpenSession();
        }

        public static void CloseSessionFactory() {
            _SessionFactory?.Close();
        }
    }
}
