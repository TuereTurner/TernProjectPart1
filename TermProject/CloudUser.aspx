<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>



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
       ul{
           list-style-type:none;
           margin-left:20px;
            padding-left: 50px;
           padding:0;
           overflow:hidden;
           background-color:black;
           position:fixed;
           top:0;
           width:100%;
            left: -20px;
            margin-right: 0;
            margin-top: 0;
            margin-bottom: 0;
        }
       li{
           float:left;
       }
       li a{
           display:block;
           color: white;
           text-align:center;
           padding:14px 16px;
           text-decoration:none;
       }
       li image{
           height:10px;
           width:10px;
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
           
             <ul>
            <li> <a href="CloudUser.aspx"> Home</a></li>
            <li> <a href="File Storage Restore.aspx"> Restore Files</a></li>
            <li> <a href="AskQuestion.aspx"> Ask Questions</a></li>

            <li style="float:right""> <a href="EditUserByUser.aspx">  <i class="fa fa-gear"></i> User Setting</a></li>
            <li style="float:right; color:cornflowerblue;"> <a href="Login.aspx" > <i class="fa fa-sign-out"></i> LogOut </a></li>
        </ul>

        </div>
        <br />

      
        <header>
            <h1>User Cloud Home</h1>
        </header>
       
             <div runat="server" id="divplaceholder" style=" background-color:white; float:right; height:124px; width:371px;  ">
    
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
         <div class="Stylediv" style=" align-content:center; float:left;padding-right:inherit;margin-right:5px; margin-left:-10px;padding-left:0px;padding-top:0px;margin-top:15px"   >
              <h5 style="width: 121px; height: 42px">Cloud Folder</h5>
             <br />
            
                  <br />
                  <br />
                  <br />

                  
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                <br />
                  <br />
                  <br />
                  <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                
        </div>
        <!---Fie schrynization-->
         <div>
             <h1> Files </h1>
        <div>


        <div class="Stylediv">
                     
     
        <asp:Label runat="server" ID="lblfileListMessage" ></asp:Label>
         
    
            
             <asp:Label runat="server" ID="LblviewfILESMesage" ></asp:Label>
                     
     <br />
            <p>

            </p>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <asp:GridView ID="GvShowaLLfiLESwITHiCON" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GvShowaLLfiLESwITHiCON_RowCancelingEdit" OnRowDeleting="GvShowaLLfiLESwITHiCON_RowDeleting" OnRowEditing="GvShowaLLfiLESwITHiCON_RowEditing" OnRowUpdating="GvShowaLLfiLESwITHiCON_RowUpdating" OnSelectedIndexChanged="GvShowaLLfiLESwITHiCON_SelectedIndexChanged" style="margin-left: 50px" Width="463px">
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
                             <asp:CommandField ButtonType="Button" HeaderText="Edit File" ShowEditButton="true" />
                             <asp:CommandField ButtonType="Button" HeaderText="Delete File" ShowDeleteButton="true" />
                         </Columns>
                     </asp:GridView>
                 </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
        </div>
        <!-- storage-->
        <div>
               <div>
                   <asp:LinkButton runat="server" OnClick="Unnamed_Click" Text="Download File"></asp:LinkButton>
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
