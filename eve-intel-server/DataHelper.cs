using System;
using System.IO;
using System.Text;
using System.Web;
using eve_intel_server.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace eve_intel_server
{
    public static class DataHelper
    {
        private const string cCurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _SessionFactory;

        static DataHelper() {
            _SessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession() {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[cCurrentSessionKey] as ISession;

            if (currentSession == null) {
                currentSession = _SessionFactory.OpenSession();
                context.Items[cCurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public static void CloseSession() {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[cCurrentSessionKey] as ISession;

            if (currentSession == null) {
                return;
            }

            currentSession.Close();
            context.Items.Remove(cCurrentSessionKey);
        }

        public static void CloseSessionFactory() {
            _SessionFactory?.Close();
        }

    }
}