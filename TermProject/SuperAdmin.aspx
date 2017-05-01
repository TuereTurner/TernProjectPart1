<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperAdmin.aspx.cs" Inherits="TermProject.SuperAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Super Admin Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblSuperAdminSelect" runat="server" Text="Select The Cloud Administrator To View Transactions"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlCloudAdministrators" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCloudAdministrators_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:gridview ID="gvTransactions" runat="server"></asp:gridview>
    </div>
    </form>
</body>
</html>
