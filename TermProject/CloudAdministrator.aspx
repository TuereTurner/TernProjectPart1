<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudAdministrator.aspx.cs" Inherits="TermProject.CloudAdministrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnEditCloudUsers" runat="server" Text="Edit Cloud Users" OnClick="btnEditCloudUsers_Click" />
        <br /> <br />
        <asp:Button ID="btnAnswerQuestion" runat="server" Text="View/Answer Questions" OnClick="btnAnswerQuestion_Click" />
        <br /> <br />
        <asp:Button ID="btnDeletCloudUsers" runat="server" Text="Delete Cloud Users" OnClick="btnDeletCloudUsers_Click" />
    </div>
    </form>
</body>
</html>
