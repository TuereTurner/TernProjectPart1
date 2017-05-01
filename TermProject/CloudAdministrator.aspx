<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudAdministrator.aspx.cs" Inherits="TermProject.CloudAdministrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator Home</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="styleSheet.css" />
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
    <form id="form1" runat="server">
<%--        <div>
            <asp:Button ID="btnEditCloudUsers" runat="server" Text="Edit Cloud Users" OnClick="btnEditCloudUsers_Click" />
            <br />
            <br />
            <asp:Button ID="btnAnswerQuestion" runat="server" Text="View/Answer Questions" OnClick="btnAnswerQuestion_Click" />
            <br />
            <br />
            <asp:Button ID="btnDeletCloudUsers" runat="server" Text="Delete Cloud Users" OnClick="btnDeletCloudUsers_Click" />
        </div>--%>
    </form>
</body>
</html>
