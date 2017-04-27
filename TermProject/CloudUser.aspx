<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnBuyMoreStorage" runat="server" Text="Buy More Storage" OnClick="btnBuyMoreStorage_Click" />
        <br /> <br />
        <asp:Button ID="btnAskQuestion" runat="server" Text="Ask/View Questions" OnClick="btnAskQuestion_Click" />
        <br /> <br />
        <asp:Button ID="btnEditInformation" runat="server" Text="Edit Information" OnClick="btnEditInformation_Click" />
    </div>
    </form>
</body>
</html>
