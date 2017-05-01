<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskQuestion.aspx.cs" Inherits="TermProject.AskQuestion" %>

<%@ Register Src="~/UserControlNavBAR.ascx" TagPrefix="uc1" TagName="UserControlNavBAR" %>


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
    <form id="form1" runat="server">
        <div>
        <uc1:UserControlNavBAR runat="server" ID="UserControlNavBAR" />

        </div>

         <div">
      <h1 style="text-align:center">&nbsp;</h1>
        <h1 style="text-align:center">Ask Quesitons</h1>

        </div>
    <div style="z-index: 1; left: 187px; top: 207px; align-content:center; position: absolute; height: 426px; width: 1159px">
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
