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
        using (ISession session = DataHelper.GetCurrentSession()) {
            EveShipInfo[] ships = session.Query<EveShipInfo>().ToArray();


            foreach (EveShipInfo ship in ships) {
    %>
        <li>
            <%= ship.Id %> - <%= ship.ShipName %> - <%= ship.Race.Name %> - T<%= ship.TechLevel %> - <%= ship.ShipType.Name %>
        </li>
    <%
            }
        }
    %>
</ul>
</body>
</html>