<%@ Page Language="C#" %>
<%@ Import Namespace="eve_intel_server.Data" %>
<script runat="server">

        private void OnClick(object sender, EventArgs e) {
            DataManager.GenerateClientDatabase();
        }

    </script>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TEST</title>
 
</head>
<body>
<form runat="server">
    <asp:Button runat="server" OnClick="OnClick" Text="UpdateClientData"/>
</form>
<%--<ul>
    <%
        using (ISession session = DataContext.OpenSession()) {
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
</ul>--%>
</body>
</html>