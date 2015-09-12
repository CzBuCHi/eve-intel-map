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
        foreach (IntelData.intelDataRow intelPlayerRow in DataHelper.IntelData) {
    %>
        <tr>
            <td><%= intelPlayerRow.characterID %></td>
            <td><%= intelPlayerRow.characterName %></td>
            <td><%= intelPlayerRow.corporationName %></td>
            <td><%= intelPlayerRow.allianceName %></td>
            <td><%= intelPlayerRow.characterKos %></td>
            <td><%= intelPlayerRow.corporationKos %></td>
            <td><%= intelPlayerRow.allianceKos %></td>
            <td><%= intelPlayerRow.solarsystemID %></td>
            <td><%= intelPlayerRow.shipTypeID %></td>
            <td><%= intelPlayerRow.notes %></td>
        </tr>
    <%
        }
    %>
</table>
</body>
</html>