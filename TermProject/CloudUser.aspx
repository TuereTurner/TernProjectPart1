<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>

<%@ Register Src="~/UserControlNavBAR.ascx" TagPrefix="uc1" TagName="UserControlNavBAR" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>

       body{
           background-color:aliceblue;
           
       }
       header{
           background-color:white;
       }
       h1{
           background-color:black;
           color:white;
           text-align:center;
           height:60px;
           margin-bottom:0px;
           margin-left:-100px;
           margin-right:-100px;
       }
       .Stylediv{
          margin-top:inherit;
           background-color:white;
           padding-top:30px;
           padding-bottom:30px;
           padding-left: 150px;
           border-bottom-color:dodgerblue;
            margin-left:auto;
           margin-right:-100px;
       }

        nav {
            float: left;
            max-width: 160px;
            margin: 0;
            padding: 1em;
            background-color:white;
            margin-left:-100px;
              padding-left: 150px;
        }

        nav ul {
                list-style-type: none;
                padding: 0;
            }

         nav ul a {
                    text-decoration: none;
                }
          
        .button{
            background-color:deepskyblue;
            font-size:20px;
            border-radius: 0%;
            color:white;
        }
    
        #form1 {
            height: 1195px;
        }
    </style>
</head>
<body>
    
     
                 
                    <div class="alert alert-warning" id="ATLAccountFailure" runat="server" visible="false">
                        <strong>Login-In Required to view this Page !</strong>
                        <a href="Login.aspx"> Log-In</a>
                    </div>
              
           
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <uc1:UserControlNavBAR runat="server" id="UserControlNavBAR" />
        </div>
        <br />

      
        <header>
            <h1>User Cloud Home</h1>
        </header>
       
             <div runat="server" id="divplaceholder" visible="false" style=" background-color:lightskyblue;border-color:white;  border:thick; float:right; height:124px; width:371px;  ">
    
 </div>     
       
         <div class="Stylediv" style=" background-color:aliceblue; align-content:center; float:left;padding-right:inherit;margin-right:5px; margin-left:-10px;padding-left:0px;padding-top:0px; width: 753px; height: 36px;"   >
        <asp:Button runat="server" Text="Upload File" ID="btnUpload"  CssClass="button" OnClick="btnUpload_Click" Height="51px" Width="187px"/>
            <asp:Label runat="server" ID="lblAddfile" ForeColor="Red" Visible="false" ></asp:Label>
              
              <asp:FileUpload runat="server" ID="BtnFileUpload" Height="27px" />
     
             <br />
</div>  
        <br />  
          
          
        <br />
        <br />
        <br />
        <br />
        <br />
        
        <!---Fie schrynization-->
          <div>
             <h1> Cloud Files</h1>
        <div>


        <div class="Stylediv">
          
                     
     <br />
           
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate>
                     <asp:Label runat="server" ID="lblNewCloudUser" ForeColor="Red" ></asp:Label>
                     <asp:GridView ID="GridViewCloudObj" runat="server" AutoGenerateColumns="False"   style="margin-left: 50px" Width="1080px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                         <Columns>
                             <asp:BoundField DataField="fileName" HeaderText="File Name" ReadOnly="true" />
                             <asp:BoundField DataField="fileType" HeaderText="File Type" ReadOnly="true" />
                             <asp:BoundField DataField="fileSize" HeaderText="Size" ReadOnly="true" />
                             <asp:BoundField DataField="uploadDate" HeaderText="Upload date" ReadOnly="true" />
                             <asp:TemplateField HeaderText=" icon">
                                 <ItemTemplate>
                                     <asp:Image ID="gvIMage" runat="server" Height="60" Width="45" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                           
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
                 </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
        </div>
         <div>
             <h1> Update and Delete Files </h1>
        <div>


        <div class="Stylediv">
                     
     
        <asp:Label runat="server" ID="lblfileListMessage" ></asp:Label>
         
    
            
             <asp:Label runat="server" ID="LblviewfILESMesage" ></asp:Label>
                     
     <br />
            <p>

            </p>
       
                
                     
                     <asp:GridView ID="GvShowaLLfiLESwITHiCON" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GvShowaLLfiLESwITHiCON_RowCancelingEdit"  OnRowDeleting="GvShowaLLfiLESwITHiCON_RowDeleting" OnRowEditing="GvShowaLLfiLESwITHiCON_RowEditing" OnRowUpdating="GvShowaLLfiLESwITHiCON_RowUpdating" OnSelectedIndexChanged="GvShowaLLfiLESwITHiCON_SelectedIndexChanged" style="margin-left: 50px" Width="463px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                         <AlternatingRowStyle BackColor="#CCCCCC" />
                         <Columns>
                             <asp:BoundField DataField="fileName" HeaderText="File Name" ReadOnly="true" />
                             <asp:BoundField DataField="fileType" HeaderText="File Type" ReadOnly="true" />
                             <asp:BoundField DataField="fileSize" HeaderText="Size" ReadOnly="true" />
                             <asp:BoundField DataField="uploadDate" HeaderText="Upload date" ReadOnly="true" />
                             <asp:TemplateField HeaderText=" icon">
                                 <ItemTemplate>
                                     <asp:Image ID="gvIMage" runat="server" Height="60" Width="45" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="UpdateFile to Newer Version">
                                 <ItemTemplate>
                                     <asp:FileUpload ID="fileUploadGV1" runat="server" />
                                 
                                 </ItemTemplate>
                             </asp:TemplateField>
                              
                             <asp:CommandField ButtonType="Button" HeaderText="Download File" ShowSelectButton="true" SelectText="Download" ControlStyle-BackColor="CornflowerBlue" ControlStyle-BorderStyle="Groove" ControlStyle-ForeColor="White">
                             <ControlStyle BackColor="CornflowerBlue" BorderStyle="Groove" ForeColor="White" />
                             </asp:CommandField>
                             <asp:CommandField ButtonType="Button" HeaderText="Edit File" ShowEditButton="true" />
                             <asp:CommandField ButtonType="Button" HeaderText="Delete File" ShowDeleteButton="true" />
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" />
                         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#808080" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#383838" />
                     </asp:GridView>
                 
           
            
        </div>
        </div>
        <!-- storage-->
        <div>
               <div>
                   
               </div>
        
        
        
        
        
        
        
        
        
        
        
        <br /> <br />
        <br /> <br />
      
    </div>

        </div>
 
           
        
        <br /> <br />
        <br /> <br />
    </form>
</body>
</html>
