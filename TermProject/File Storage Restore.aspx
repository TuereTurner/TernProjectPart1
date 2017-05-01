<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="File Storage Restore.aspx.cs" Inherits="TermProject.File_Storage_Restore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="styleSheet.css"/>
    <title>File Restore</title>
    
</head>
<body>
    
     
                 
                    <div class="alert alert-warning" id="ATLAccountFailure" runat="server" visible="false">
                        <strong>Login-In Required to view this Page !</strong>
                        <a href="Login.aspx"> Log-In</a>
                    </div>
              
           
    <form id="form1" runat="server">
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

       <br />
        <header > Restore Files </header>
        <br />
        <br />
        <h1>Restore Deleted Files</h1>
        <div class="Stylediv">
                 <asp:Label runat="server" ID="lbldelectedfilerecover"></asp:Label>

        <asp:GridView ID="GridVDeletedFiles" runat="server" AutoGenerateColumns="False" Width="913px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridVDeletedFiles_SelectedIndexChanged">
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:CheckBox runat="server" id="chkGridDelete" />
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="fileName" HeaderText="File Name" />
               <asp:BoundField DataField="DateDeleted" HeaderText="Date Deleted" />
               <asp:BoundField DataField="fileType" HeaderText="File Type" />
               <asp:BoundField DataField="fileSize" HeaderText=" Size" />

           </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:Button runat="server" Text="Recover Deleted File" ID="BTNDeletedFileReover" CssClass="button" OnClick="BTNDeletedFileReover_Click"/>
    </div>
        
        <h1>Restore File to Previous Verison</h1>
             <div class="Stylediv">
                 <asp:Label runat="server" ID="lblrecoverfile"></asp:Label>
        <asp:GridView ID="GridViewVersionRecover" runat="server" AutoGenerateColumns="False" Width="941px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:CheckBox runat="server" id="chkGridVerison"/>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="fileName" HeaderText="File Name" />
               <asp:BoundField DataField="VersionNumber" HeaderText="File Verison " />

               <asp:BoundField DataField="DateReplaced" HeaderText="Date Modified " />
               <asp:BoundField DataField="fileType" HeaderText="Type" />
               <asp:BoundField DataField="fileSize" HeaderText="Size" />

           </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:Button runat="server" Text="Restore File" ID="btnResoreVerson" CssClass="button" OnClick="btnResoreVerson_Click"/>
             
    </div>
    
    </form>
</body>
</html>
