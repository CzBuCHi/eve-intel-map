using System;
using System.Web;
using log4net;

namespace eve_intel_server
{
    public class Global : HttpApplication
    {
        private static readonly ILog _Logger = LogManager.GetLogger(typeof (Global));

        protected void Application_Start(object sender, EventArgs e) {
            _Logger.Debug("[Start]");
        }

        protected void Session_Start(object sender, EventArgs e) {
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
        }

        protected void Application_Error(object sender, EventArgs e) {
            _Logger.Debug("[Error]");
        }

        protected void Session_End(object sender, EventArgs e) {
        }

        protected void Application_End(object sender, EventArgs e) {
            _Logger.Debug("[Stop]");
        }
    }
}
