<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCloudUsers.aspx.cs" Inherits="TermProject.EditCloudUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvEditUserByAdmin" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="gvEditUserByAdmin_RowCancelingEdit" OnRowEditing="gvEditUserByAdmin_RowEditing" OnRowUpdating="gvEditUserByAdmin_RowUpdating1" OnRowUpdated="gvEditUserByAdmin_RowUpdated" OnSelectedIndexChanged="gvEditUserByAdmin_SelectedIndexChanged">
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
        </asp:GridView>
    </div>
    </form>
</body>
</html>
