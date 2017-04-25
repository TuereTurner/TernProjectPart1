<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>

<%@ Register Src="http://localhost:12400/WebUserControlShowFIle.ascx" TagPrefix="uc1" TagName="WebUserControlShowFIle" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager runat="server" ID="sCRIPTMANAGER"></asp:scriptmanager>
    <div>
    


        <!---AJAX FOR FILE SCHELVS-->
        <div runat="server" id="fILEaJAX">
            <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">


            </asp:ScriptManagerProxy>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            
            
            </asp:UpdatePanel>
        </div>
    </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <!-- when a file is uploaded it shows in the box-->
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
               


            </asp:PlaceHolder>
        </p>
    </form>
</body>
</html>
