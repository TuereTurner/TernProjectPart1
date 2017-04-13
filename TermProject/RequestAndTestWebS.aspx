<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestAndTestWebS.aspx.cs" Inherits="TermProject.RequestAndTestWebS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>



    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Log in Page</title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            left: 15px;
            top: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

       <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-md-offset-3">
                    <div class="alert alert-success" id="ATLSuccessAlert" runat="server" visible="false">
                        <strong> Successfull Login!</strong>

                    </div>
                    <div class="alert alert-warning" id="ATLAccountFailure" runat="server" visible="false">
                        <strong>Wrong User Name or Password!</strong>

                    </div>
                </div>
            </div>
            </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-5 col-md-offset-4">
                    <div class="page-header">
                        <h1 style="align-content: center; color: lightslategray">
                            <b>Log In</b></h1>
                    </div>
                </div>
            </div>
            <div class="span3">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-5 col-md-offset-3">
                            <div class="form-group">

                                <label for="txtusername">AccesNet User Name</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <label for="txtAppID">Password:</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <br />
                            <br />
                            <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary btn-sm" Text="Log in" OnClick="btnLogin_Click" /> <br/> <br/>
                            <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-primary btn-sm" Text="Register" OnClick="btnRegister_Click" />
                            <asp:CheckBox ID="chkRememberMe" runat="server" style="z-index: 1; left: 355px; top: 170px; position: absolute"></asp:CheckBox>
                            <asp:Label ID="lblRememberMe" runat="server" Text="Remember Me" style="z-index: 1; left: 250px; top: 170px; position: absolute"></asp:Label></div>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

