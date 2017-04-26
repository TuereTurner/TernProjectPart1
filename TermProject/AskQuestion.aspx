<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskQuestion.aspx.cs" Inherits="TermProject.AskQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <asp:Label ID="lblAskQuestion" runat="server" Text="Type Question Here: "></asp:Label>
        <br />
        <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Height="105px" Width="245px"></asp:TextBox>
        <asp:Button ID="btnAskQuestion" runat="server" Text="Ask Question" OnClick="btnAskQuestion_Click" />
        <br /> <br /> <br />
        <asp:Label ID="lblQuestions" runat="server" Text="View Questions Below:"></asp:Label>
        <br /> <br />
        <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Username"/>
                <asp:BoundField DataField="question" HeaderText="Question"/>
                <asp:BoundField DataField="answerUsername" HeaderText="Answered By"/>
                <asp:BoundField DataField="answer" HeaderText="Answer"/>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
