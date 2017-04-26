<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyMoreStorage.aspx.cs" Inherits="TermProject.BuyMoreStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblHowMuch" runat="server" Text="Choose the storage plan you would like."></asp:Label>
        <asp:DropDownList ID="ddlStoragePlans" runat="server" style="z-index: 1; left: 262px; top: 15px; position: absolute"></asp:DropDownList>

        <asp:Label ID="lblName" runat="server" Text="Name on Credit Card:" style="z-index: 1; left: 14px; top: 70px; position: absolute"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" style="z-index: 1; left: 196px; top: 70px; position: absolute; width: 225px;"></asp:TextBox>

        <asp:Label ID="lblCreditCardNumber" runat="server" Text="Credit Card Number:" style="z-index: 1; left: 14px; top: 120px; position: absolute"></asp:Label>
        <asp:TextBox ID="txtCreditCardNumber" runat="server" style="z-index: 1; left: 196px; top: 120px; position: absolute; width: 225px;"></asp:TextBox>
    
        <asp:Label ID="lblExpirationData" runat="server" Text="Expiration Date:" style="z-index: 1; left: 14px; top: 170px; position: absolute; right: 768px;"></asp:Label>
        <asp:TextBox ID="txtExpirationDate" placeholder="mm/yyyy" runat="server" style="z-index: 1; left: 196px; top: 170px; position: absolute; width: 54px;"></asp:TextBox>  
              
        <asp:Label ID="lblOutput" runat="server" Text="" style="z-index: 1; left: 794px; top: 170px; position: absolute"></asp:Label>
              
        <asp:Label ID="lblCVV" runat="server" Text="CVV:" style="z-index: 1; left: 302px; top: 170px; position: absolute; right: 536px;"></asp:Label>
        <asp:TextBox ID="txtCVV" runat="server" style="z-index: 1; left: 365px; top: 170px; position: absolute; width: 59px;"></asp:TextBox>            
    
        <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address:" style="z-index: 1; left: 14px; top: 220px; position: absolute; right: 729px;"></asp:Label>
        <asp:TextBox ID="txtBillingAddress" runat="server" style="z-index: 1; left: 196px; top: 220px; position: absolute; width: 225px;"></asp:TextBox>            

        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" style="z-index: 1; left: 14px; top: 270px; position: absolute; right: 729px;"></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server" style="z-index: 1; left: 196px; top: 270px; position: absolute; width: 225px;"></asp:TextBox>            
        
        <asp:Button ID="btnPurchase" runat="server" Text="Purchase" style="z-index: 1; left: 14px; top: 320px; position: absolute" OnClick="btnPurchase_Click" />
    </div>
    </form>
</body>
</html>
