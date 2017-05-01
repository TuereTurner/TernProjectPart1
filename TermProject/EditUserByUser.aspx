<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserByUser.aspx.cs" Inherits="TermProject.EditUserByUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="styleSheet.css"/>
</head>
<body>
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
    <br /><br /><br />
    <form id="form1" runat="server">
        <div>
            <br /> <br />
            <asp:GridView ID="gvEditUser" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvEditUser_RowCancelingEdit" OnRowEditing="gvUserEditUser_RowEditing" OnRowUpdated="gvUserEditUser_RowUpdated" OnRowUpdating="gvUserEditUser_RowUpdating" Width="1400px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="true" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                    <asp:BoundField DataField="typeOfUser" HeaderText="Type Of User" ReadOnly="true" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="totalCapacity" HeaderText="Total Capacity" ReadOnly="true" />


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
