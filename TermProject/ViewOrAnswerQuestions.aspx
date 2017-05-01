<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrAnswerQuestions.aspx.cs" Inherits="TermProject.ViewOrAnswerQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questions</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
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
        <asp:GridView ID="gvQuestions" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="891px">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <br /> <br /> <br />
        <asp:Label ID="lblQuestionsID" runat="server" Text="Enter questionID for the question you want to answer:"></asp:Label>
        <br />
        <asp:TextBox ID="txtQuestionsID" runat="server"></asp:TextBox>
        <br /> <br />
        <asp:Label ID="lblAnswer" runat="server" Text="Enter Answer Below"></asp:Label>
        <br />
        <asp:TextBox ID="txtAnswer" runat="server" Height="84px" TextMode="MultiLine" Width="264px"></asp:TextBox>
        <br /> <br /> <br />
        <asp:Button ID="btnAnswerQuestion" runat="server" Text="Answer Question" OnClick="btnAnswerQuestion_Click" />
    </div>
    </form>
</body>
</html>
