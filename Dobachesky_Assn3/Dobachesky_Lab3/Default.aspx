<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dobachesky_Lab3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnGetForecast" runat="server" Text="Get Forecast" OnClick="btnGetForecast_Click" /><br />
        <asp:TextBox ID="txtForecast" runat="server" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox><br />

        <br />
        <br />

        <asp:Button ID="btnGetZipCities" runat="server" Text="Get Cities for Zip" OnClick="btnGetZipCities_Click" />
        <asp:Button ID="btnGetNearby" runat="server" Text="Get Nearby Cities" OnClick="btnGetNearby_Click" />
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="txtZipOutput" runat="server" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox><br />
    </div>
    </form>
</body>
</html>
