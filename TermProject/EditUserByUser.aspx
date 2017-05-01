<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserByUser.aspx.cs" Inherits="TermProject.EditUserByUser" %>

<%@ Register Src="~/UserControlNavBAR.ascx" TagPrefix="uc1" TagName="UserControlNavBAR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS%20%20Style/BodyStyleSheet.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
        <uc1:UserControlNavBAR runat="server" ID="UserControlNavBAR" />
        <div>
             <div">
      <h1 style="text-align:center">&nbsp;</h1>
        <h1 style="text-align:center">Edit Profile</h1>

        </div>
            <br /> 
            <asp:GridView ID="gvEditUser" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvEditUser_RowCancelingEdit" OnRowEditing="gvUserEditUser_RowEditing" OnRowUpdated="gvUserEditUser_RowUpdated" OnRowUpdating="gvUserEditUser_RowUpdating" Width="1400px">
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
            </asp:GridView>

        <br />

        </div>
    </form>
</body>
</html>
