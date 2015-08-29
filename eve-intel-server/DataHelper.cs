using NHibernate;
using NHibernate.Cfg;

namespace eve_intel_server
{
    public static class DataHelper
    {
        private static readonly ISessionFactory _SessionFactory;

        static DataHelper() {
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
