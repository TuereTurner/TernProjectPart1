<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  
    
     
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    
    
    <style>
      /*  <--!--reference w3schools bootstrap -->*/

.dropbtn {
    background-color:dodgerblue;
    color: white;
    padding: 16px;
    font-size: 16px;
    border: none;
    cursor: pointer;
}

.dropdown {
    position: relative;
    display: inline-block;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color:black;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
}

.dropdown-content a:hover {background-color:black}

.dropdown:hover .dropdown-content {
    display: block;
}

.dropdown:hover .dropbtn {
    background-color:black;
}
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h1>&nbsp;</h1>
                <h1>&quot;Cloud&quot; Registration</h1>
                <p>Welcome!!! </p>

                <p>Please fill out all the information below to Register .</p>

            </div>
        </div>
        <br />
         <div class="row">

                <div class="col-sm-4 col-xs-offset-2">
                    <label class="col-2 col-form-label">First Name</label>
                    <div class="col-10">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" type="text" required="true">
                        
                        </asp:TextBox>
                    </div>


                </div>
                <div class="col-sm-4 ">
                    <label class="col-2 col-form-label">Type Of User</label>
                    <div class="col-10">
                        <div class="dropdown">
                            <asp:DropDownList runat="server" ID="drpTypeOfUser" CssClass="dropbtn">
                                <asp:ListItem Value="Cloud User" Cssclass="dropdown-content">
                              
                                </asp:ListItem>
                                <asp:ListItem Value="Cloud Administraion" Cssclass="dropdown-content"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
            </div>
       
        <div class="row">
            <div class="col-sm-8 col-xs-offset-2">
                <label class="col-2 col-form-label">Email</label>
                <div class="col-10">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email" required="true"></asp:TextBox>
                    
                </div>
            </div>
            <br />
        </div>
        <br />
        <div class="row">
            <div class="col-sm-8 col-xs-offset-2">
                <label class="col-2 col-form-label">Address</label>
                <div class="col-10">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" type="text" required="true"></asp:TextBox>

                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3 col-xs-offset-2">
                    <label class="col-2 col-form-label">City</label>
                    <div class="col-10">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" type="text" required="true"></asp:TextBox>

                    </div>
                </div>
                <div class="col-sm-3">
                    <label class="col-2 col-form-label">State</label>
                    <div class="col-5">
                        <asp:TextBox ID="txtSate" runat="server" CssClass="form-control" type="text" required="true"></asp:TextBox>

                    </div>
                </div>

                <div class="col-sm-1">
                    <label class="col-2 col-form-label">Zip</label>
                    <div class="col-5">
                        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" type="numbrt" required="true"></asp:TextBox>

                    </div>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-sm-8 col-xs-offset-2">
                    <label class="col-2 col-form-label">Phone Number</label>
                    <div class="col-10">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" type="number" required="true"></asp:TextBox>

                    </div>
                </div>

            </div>
        <br />
            <div class="row">
                <div class="col-sm-4 col-xs-offset-2">
                    <label class="col-2 col-form-label">Username</label>
                    <div class="col-10">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" type="text" required="true"></asp:TextBox>

                    </div>
                </div>
                
                <div class="col-sm-4 ">
                    <label class="col-2 col-form-label">Password</label>
                    <div class="col-10">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="text" required="true"></asp:TextBox>

                    </div>
                </div>
                           <div class="col-sm-2">
                    <div class="col-10">
                        <asp:CheckBox runat="server" CssClass="checkbox" Text="Store Cookies" ID="chkStorecookies" />
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="form-group">
                        <asp:Button runat="server" CssClass="btn btn-primary btn-md btn-block" Text="Sumbit" ID="btnSubmitInfo" OnClick="btnSubmit_Click" />
                    </div>
                </div>


            </div>

            <br />
            <br />

            <br />
            <br />


         
            <br />
            <br />
            <br />





       

    </form>
</body>
</html>
