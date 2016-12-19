<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Midterm_pt3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtMidterm3a" runat="server" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="txtMidterm3b" runat="server" Width="500" Height="200" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="btnMidterm" runat="server" Text="Read Data" OnClick="btnMidterm_Click" />
    </div>
    </form>
</body>
</html>
