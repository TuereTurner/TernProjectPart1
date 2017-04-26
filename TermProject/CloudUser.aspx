<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>

       body{
           background-color:#1E88E5;
           
       }
       header{
           background-color:white;
       }
       h1{
           background-color:black;
           color:white;
           text-align:center;
           height:70px;
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
            margin-left:-100px;
           margin-right:-100px;
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
    </style>
</head>
<body>
    
     
                 
                    <div class="alert alert-warning" id="ATLAccountFailure" runat="server" visible="false">
                        <strong>Login-In Required to view this Page !</strong>
                        <a href="Login.aspx"> Log-In</a>
                    </div>
              
           
    <form id="form1" runat="server">
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
        <br />
        <br />
        <!---Fie schrynization-->
<h1> Files </h1>

        <div class="Stylediv">
                     <asp:TextBox AutoPostBack="true" OnTextChanged="txtGetAllFilesicon_TextChanged" runat="server" ID="txtGetAllFilesicon" placeholder="Enter User Name"></asp:TextBox>
     
             <asp:Label runat="server" ID="LblviewfILESMesage" ></asp:Label>
        <asp:Label runat="server" ID="lblfileListMessage" ></asp:Label>
         
             <asp:GridView ID="GvShowaLLfiLESwITHiCON" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GvShowaLLfiLESwITHiCON_RowCancelingEdit" OnRowDeleting="GvShowaLLfiLESwITHiCON_RowDeleting" OnRowEditing="GvShowaLLfiLESwITHiCON_RowEditing" OnRowUpdating="GvShowaLLfiLESwITHiCON_RowUpdating" Width="463px" OnSelectedIndexChanged="GvShowaLLfiLESwITHiCON_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="fileName" HeaderText="File Name" ReadOnly="true"/>
                <asp:BoundField DataField="fileType" HeaderText="File Type" ReadOnly="true" />
                <asp:BoundField DataField="fileSize" HeaderText="Size" ReadOnly="true"/>
                <asp:BoundField DataField="uploadDate" HeaderText="Upload date" ReadOnly="true"  />
                <asp:TemplateField HeaderText=" icon">
                    <ItemTemplate>
                        <asp:Image runat="server" id="gvIMage" Height="60" Width="45"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdateFile to Newer Version">
                    <ItemTemplate>
                        <asp:FileUpload runat="server" ID="fileUploadGV1" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Button" HeaderText="Edit File" ShowEditButton="true" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete File" ShowDeleteButton="true" />

            </Columns>
        </asp:GridView>
            
    <%--<uc1:WebUserControlShowFIle runat="server" id="WebUserControlShowFIle" /> --%>
        </div>
        </div>
        <!-- storage-->
        <div>
               <h1 > Buy More Storage</h1>
    <div class="Stylediv" >
        <h3>Choose the storage plan you would like. </h3>
        <div>
             
        
        <asp:DropDownList ID="ddlStoragePlans" runat="server" style="z-index: 1; left: 820px; top: 927px; position: absolute"></asp:DropDownList>

        <asp:Label ID="lblName" runat="server" Text="Name on Credit Card:" ></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

        <asp:Label ID="lblCreditCardNumber" runat="server" Text="Credit Card Number:" ></asp:Label>
        <asp:TextBox ID="txtCreditCardNumber" runat="server" ></asp:TextBox>
    
        <asp:Label ID="lblExpirationData" runat="server" Text="Expiration Date:" ></asp:Label>
        <asp:TextBox ID="txtExpirationDate" placeholder="mm/yyyy" runat="server" ></asp:TextBox>  
              
        <asp:Label ID="lblOutput" runat="server" Text="" ></asp:Label>
              
        <asp:Label ID="lblCVV" runat="server" Text="CVV:" ></asp:Label>
        <asp:TextBox ID="txtCVV" runat="server" ></asp:TextBox>            
    
        <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address:" ></asp:Label>
        <asp:TextBox ID="txtBillingAddress" runat="server" ></asp:TextBox>            

        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" ></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server" ></asp:TextBox>            
        
        <asp:Button ID="btnPurchase" runat="server" Text="Purchase"  OnClick="btnPurchase_Click" />
    
        
        </div>
        <asp:Button ID="btnBuyMoreStorage" cs runat="server" Text="Buy More Storage" OnClick="btnBuyMoreStorage_Click" />
          
        
        
        
        
        
        
        
        
        
        
        
        
        
        <br /> <br />
        <br /> <br />
    </div>

        </div>
 
        <h1> Ask Questions</h1>
        <div class="Stylediv">
        <asp:Button ID="btnAskQuestion" runat="server" Text="Ask/View Questions" OnClick="btnAskQuestion_Click" />

        </div>

        <h1> Edit Information</h1>
          <div class="Stylediv">
               <asp:Button ID="btnEditInformation" runat="server" Text="Edit Information" OnClick="btnEditInformation_Click" />


        </div>
    </form>
</body>
</html>
