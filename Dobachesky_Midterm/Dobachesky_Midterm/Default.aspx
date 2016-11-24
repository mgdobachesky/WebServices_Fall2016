<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dobachesky_Midterm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblMidterm1" runat="server">
            <asp:TableRow id="tblRow1" runat="server">
                <asp:TableCell>Owner</asp:TableCell>
                <asp:TableCell ID="cell1" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow id="tblRow2" runat="server">
                <asp:TableCell>Account ID</asp:TableCell>
                <asp:TableCell ID="cell2" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow id="tblRow3" runat="server">
                <asp:TableCell>Total Amount</asp:TableCell>
                <asp:TableCell ID="cell3" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnMidterm1" runat="server" Text="Get Info" OnClick="btnMidterm1_Click" />

    </div>
    </form>
</body>
</html>
