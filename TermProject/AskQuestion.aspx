<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskQuestion.aspx.cs" Inherits="TermProject.AskQuestion" %>

<%@ Register Src="~/UserControlNavBAR.ascx" TagPrefix="uc1" TagName="UserControlNavBAR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS%20%20Style/BodyStyleSheet.css" rel="stylesheet" />
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
        <uc1:UserControlNavBAR runat="server" ID="UserControlNavBAR" />

        </div>

         <div">
      <h1 style="text-align:center">&nbsp;</h1>
        <h1 style="text-align:center">Ask Quesitons</h1>

        </div>
    <div style="z-index: 1; left: 187px; top: 207px; align-content:center; position: absolute; height: 426px; width: 1159px">
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
