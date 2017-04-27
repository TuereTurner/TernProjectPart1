<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCloudUsers.aspx.cs" Inherits="TermProject.DeleteCloudUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:dropdownlist ID="ddlDeleteCloudUsers" runat="server"></asp:dropdownlist>
        <br /> <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    </div>
    </form>
</body>
</html>
