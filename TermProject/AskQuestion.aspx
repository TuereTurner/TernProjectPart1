<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskQuestion.aspx.cs" Inherits="TermProject.AskQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questions</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="styleSheet.css"/>
    <style type="text/css">
        #txtAskQuestion {
            height: 123px;
            width: 251px;
        }
    </style>
</head>
<body>
    <br /><br /><br /><br />
            <div>
            <ul>
                <li><a href="CloudUser.aspx">Home</a></li>
                <li><a href="File Storage Restore.aspx">Restore Files</a></li>
                <li><a href="AskQuestion.aspx">Ask Questions</a></li>
                <li><a href="BuyMoreStorage.aspx">Buy More Storage</a></li>

                <li style="float: right"><a href="EditUserByUser.aspx"><i class="fa fa-gear"></i>User Setting</a></li>
                <li style="float: right; color: cornflowerblue;"><a href="Login.aspx"><i class="fa fa-sign-out"></i>LogOut </a></li>
            </ul>
        </div>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblAskQuestion" runat="server" Text="Type Question Here: "></asp:Label>
        <br />
        <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Height="105px" Width="265px"></asp:TextBox>
        <asp:Button ID="btnAskQuestion" runat="server" Text="Ask Question" OnClick="btnAskQuestion_Click" />
        <br /> <br /> <br />
        <asp:Label ID="lblQuestions" runat="server" Text="View Questions Below:"></asp:Label>
        <br /> <br />
        <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="674px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Username"/>
                <asp:BoundField DataField="question" HeaderText="Question"/>
                <asp:BoundField DataField="answerUsername" HeaderText="Answered By"/>
                <asp:BoundField DataField="answer" HeaderText="Answer"/>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
