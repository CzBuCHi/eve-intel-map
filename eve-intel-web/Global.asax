<%@ Application Language="C#" %>
<%@ Import Namespace="log4net" %>

<script RunAt="server">

    private ILog _Logger;

    protected void Application_Start(object sender, EventArgs e) {
        _Logger = LogManager.GetLogger(GetType());
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

</script>
