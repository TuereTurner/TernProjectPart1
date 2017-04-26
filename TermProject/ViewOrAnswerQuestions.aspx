<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrAnswerQuestions.aspx.cs" Inherits="TermProject.ViewOrAnswerQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
