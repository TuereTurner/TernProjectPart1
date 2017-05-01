<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCloudUsers.aspx.cs" Inherits="TermProject.DeleteCloudUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Or Disable</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="styleSheet.css" />
    <link rel="stylesheet" href="styleSheet.css"/>
</head>
<body>
    <div>

        <ul>
            <li><a href="CloudAdministrator.aspx">Home</a></li>
            <li><a href="EditCloudUsers.aspx">Edit Cloud Users</a></li>
            <li><a href="ViewOrAnswerQuestions.aspx">Answer Questions</a></li>
            <li><a href="DeleteCloudUsers.aspx">Delete Or Disable Users</a></li>

            <li style="float:right; color:cornflowerblue;"><a href="Login.aspx"><i class="fa fa-sign-out"></i>LogOut </a></li>
        </ul>

    </div>
    <br /><br /><br />
    <form id="form1" runat="server">
    <div>
        <asp:dropdownlist ID="ddlDeleteCloudUsers" runat="server"></asp:dropdownlist>
        <br /> <br />
        <asp:Button ID="btnEnable" runat="server" Text="Enable" OnClick="btnEnable_Click" />        
        <br /><br />
        <asp:Button ID="btnDisable" runat="server" Text="Disable" OnClick="btnDisable_Click" />
        <br /><br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <br /><br /><br /><br />
        <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
