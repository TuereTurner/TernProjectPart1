<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCloudUsers.aspx.cs" Inherits="TermProject.EditCloudUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Users</title>
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
        <asp:GridView ID="gvEditUserByAdmin" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvEditUserByAdmin_RowCancelingEdit" OnRowEditing="gvEditUserByAdmin_RowEditing" OnRowUpdating="gvEditUserByAdmin_RowUpdating1" OnRowUpdated="gvEditUserByAdmin_RowUpdated" OnSelectedIndexChanged="gvEditUserByAdmin_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Username"/>
                <asp:BoundField DataField="password" HeaderText="Password" />
                <asp:BoundField DataField="typeOfUser" HeaderText="Type Of User" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number" />
                <asp:BoundField DataField="totalCapacity" HeaderText="Total Capacity"  />
               
                
                 <asp:CommandField ButtonType="Button" HeaderText="Edit Account" ShowEditButton="true" />

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
