<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyMoreStorage.aspx.cs" Inherits="TermProject.BuyMoreStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buy More Storage</title>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
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
    <form id="form1" runat="server" style="margin-bottom:100px;">
    <div style="margin-bottom:100px;">
        <asp:Label ID="lblHowMuch" runat="server" Text="Choose the storage plan you would like:" style="z-index: 1; left: 10px; top: 55px; position: absolute"></asp:Label>

        <asp:Label ID="lblName" runat="server" Text="Name on Credit Card:" style="z-index: 1; left: 14px; top: 93px; position: absolute"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" style="z-index: 1; left: 195px; top: 93px; position: absolute; width: 225px;"></asp:TextBox>

        <asp:Label ID="lblCreditCardNumber" runat="server" Text="Credit Card Number:" style="z-index: 1; left: 14px; top: 140px; position: absolute"></asp:Label>
        <asp:TextBox ID="txtCreditCardNumber" runat="server" style="z-index: 1; left: 197px; top: 140px; position: absolute; width: 225px;"></asp:TextBox>
    
        <asp:Label ID="lblExpirationData" runat="server" Text="Expiration Date:" style="z-index: 1; left: 14px; top: 190px; position: absolute; right: 768px;"></asp:Label>
        <asp:TextBox ID="txtExpirationDate" placeholder="mm/yyyy" runat="server" style="z-index: 1; left: 197px; top: 191px; position: absolute; width: 54px;"></asp:TextBox>  
              
        <asp:Label ID="lblOutput" runat="server" Text="" style="z-index: 1; left: 794px; top: 170px; position: absolute"></asp:Label>
              
        <asp:Label ID="lblCVV" runat="server" Text="CVV:" style="z-index: 1; left: 303px; top: 191px; position: absolute; right: 535px;"></asp:Label>
        <asp:TextBox ID="txtCVV" runat="server" style="z-index: 1; left: 366px; top: 192px; position: absolute; width: 59px;"></asp:TextBox>            
    
        <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address:" style="z-index: 1; left: 14px; top: 240px; position: absolute; right: 729px;"></asp:Label>
        <asp:TextBox ID="txtBillingAddress" runat="server" style="z-index: 1; left: 198px; top: 241px; position: absolute; width: 225px;"></asp:TextBox>            

        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" style="z-index: 1; left: 14px; top: 290px; position: absolute; right: 729px;"></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server" style="z-index: 1; left: 197px; top: 290px; position: absolute; width: 225px;"></asp:TextBox>            
        
        <asp:Button ID="btnPurchase" runat="server" Text="Purchase" style="z-index: 1; left: 14px; top: 353px; position: absolute" OnClick="btnPurchase_Click" />
        <asp:DropDownList ID="ddlStoragePlans" runat="server" style="z-index: 1; left: 303px; top: 55px; position: absolute"></asp:DropDownList>

    </div>
    </form>
</body>
</html>
