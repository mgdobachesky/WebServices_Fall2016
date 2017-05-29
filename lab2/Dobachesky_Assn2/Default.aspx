<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dobachesky_Assn2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Michael Dobachesky - Assignment 2</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Invoice</h1>
        <asp:Label ID="lblNumber" runat="server" Text="Number of items bought: "></asp:Label><br />
        <asp:Label ID="lblTotal" runat="server" Text="Total cost or order: $"></asp:Label><br />

        <h4>Billing Information</h4>
        <asp:TextBox ID="txtBilling" runat="server" TextMode="MultiLine" Width="350px"  Height="150px"></asp:TextBox>

        <h4>Shipping Information</h4>
         <asp:TextBox ID="txtShipping" runat="server" TextMode="MultiLine" Width="350px"  Height="150px"></asp:TextBox>

        <h4>Item Information</h4>
         <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Width="350px"  Height="150px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
