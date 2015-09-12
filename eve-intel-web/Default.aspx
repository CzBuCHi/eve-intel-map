<%@ Page Language="C#" %>
<%@ Import Namespace="eve_intel_server.Data" %>
<%@ Import Namespace="eve_intel_server" %>
<script runat="server">

    private void OnClick(object sender, EventArgs e) {
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
<table>
    <tr>
        <th>characterID</th>
        <th>characterName</th>
        <th>corporationName</th>
        <th>allianceName</th>
        <th>characterKos</th>
        <th>corporationKos</th>
        <th>allianceKos</th>
        <th>solarsystemID</th>
        <th>shipTypeID</th>
        <th>notes</th>
    </tr>
    <%
        var data = new IntelData();
        foreach (var intelPlayerRow in data.IntelDataTable) {
    %>
        <tr>
            <td><%= intelPlayerRow.CharacterID %></td>
            <td><%= intelPlayerRow.CharacterName %></td>
            <td><%= intelPlayerRow.CorporationName %></td>
            <td><%= intelPlayerRow.AllianceName %></td>
            <td><%= intelPlayerRow.CharacterKos %></td>
            <td><%= intelPlayerRow.CorporationKos %></td>
            <td><%= intelPlayerRow.AllianceKos %></td>
            <td><%= intelPlayerRow.SolarsystemID %></td>
            <td><%= intelPlayerRow.ShipTypeID %></td>
            <td><%= intelPlayerRow.Notes %></td>
        </tr>
    <%
        }
    %>
</table>
</body>
</html>