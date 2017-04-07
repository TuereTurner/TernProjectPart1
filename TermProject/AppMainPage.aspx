<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppMainPage.aspx.cs" Inherits="TermProject.AppMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- error message if user not logged in -->
      <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-md-offset-3">
                 
                    <div class="alert alert-warning" id="ATLAccountFailure" runat="server" visible="false">
                        <strong>Login-In Required to view this Page !</strong>
                        <a href="Login.aspx"> Log-In</a>
                    </div>
                </div>
            </div>
            </div>
    </form>
</body>
</html>
