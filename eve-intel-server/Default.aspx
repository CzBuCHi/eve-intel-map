<%@ Page Language="C#" %>
<%@ Import Namespace="eve_intel_server" %>
<%@ Import Namespace="eve_intel_server.Domain" %>
<%@ Import Namespace="log4net" %>
<%@ Import Namespace="NHibernate" %>
<%@ Import Namespace="NHibernate.Linq" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TEST</title>
</head>
<body>
<ul>
    <%
        EveRace[] races;
        using (ISession session = DataHelper.GetCurrentSession()) {
            races = session.Query<EveRace>().ToArray();
        }
        
        foreach (EveRace race in races) {
    %>
        <li>
            <%= race.Id %> - <%= race.Name %>
        </li>
    <%	
        }
    %>
</ul>
</body>
</html>