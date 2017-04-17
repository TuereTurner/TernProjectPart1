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
        #divMethods {
            height: 1446px;
            z-index: 1;
            left: -232px;
            top: 535px;
            position: absolute;
            width: 987px;
            margin-left: 469px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
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
                            Request Access for WebService:File </h1>
                    </div>
                </div>
            </div>
            <div class="span3">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-5 col-md-offset-3">
                            <div class="form-group">

                                <label for="txtusername">Chooses Username</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <label for="txtAppID">Assigned API-Key</label>
                                <asp:TextBox ID="TxtAPIKey" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

                            </div>
                            <br />
                            <br />
                            <asp:Button runat="server" ID="btnGetAPIKey" CssClass="btn btn-primary btn-sm" Text="Get API Key" OnClick="btnGetAPIKey_Click" /> <br/> <br/>
                            </div>
                        
                    </div>
                </div>
    </div>
    </div>
        </div>
    <div id="divMethods" runat="server">
        <!--Add file for cloud user-->
        <div>    <h1>Add a File</h1>
       <asp:Label runat="server" ID="lblAddfile" ForeColor="Red" Visible="false" ></asp:Label>
        <asp:FileUpload runat="server" ID="BtnFileUpload" />

        <asp:TextBox ID="txtApiKeyFileupload" runat="server" placeholder="API Key"></asp:TextBox>
       
        <asp:TextBox ID="txtAccountUsername" runat="server"  placeholder="User Name" ></asp:TextBox>
<asp:Button runat="server" ID="btnUploadFile" OnClick="btnUploadFile_Click" Text="Upload File to Account" />
<asp:PlaceHolder runat="server" ID="placeImage">
        <asp:Image runat="server" ID="ImgFileIcon" Height="60" Width="45" />
    </asp:PlaceHolder>
</div>
     <div>
 <h1>Edit Files</h1>
         <asp:TextBox AutoPostBack="true" OnTextChanged="txtuserNameGetAllFiles_TextChanged" runat="server" ID="txtuserNameGetAllFiles" placeholder="Enter User Name"></asp:TextBox>
        <asp:Label runat="server" ID="lblfileListMessage" ></asp:Label>
         <!-- EDit delete and update file-->
        <asp:GridView ID="GvFiles" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GvFiles_RowCancelingEdit" OnRowDeleting="GvFiles_RowDeleting" OnRowEditing="GvFiles_RowEditing" OnRowUpdating="GvFiles_RowUpdating" Width="463px">
            <Columns>
                <asp:BoundField DataField="fileName" HeaderText="File Name" ReadOnly="true"/>
                <asp:BoundField DataField="fileType" HeaderText="File Type" ReadOnly="true" />
                <asp:BoundField DataField="fileSize" HeaderText="Size" ReadOnly="true"/>
                <asp:BoundField DataField="uploadDate" HeaderText="Upload date" ReadOnly="true"  />
                <asp:TemplateField HeaderText="UpdateFile to Newer Version">
                    <ItemTemplate>
                        <asp:FileUpload runat="server" ID="fileUploadGV" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" HeaderText="Edit File" ShowEditButton="true" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete File" ShowDeleteButton="true" />

            </Columns>
        </asp:GridView>
     </div>
       
        <!--add accoumnt cloud admin-->
        <div>
        <h1>Add Cloud User And Admin</h1>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-md-offset-3">
                    
                </div>
            </div>
            </div>
            <div class="row">

                <div class="col-sm-4 ">
                    <label class="col-2 col-form-label">First Name</label>
                    <div class="col-10">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" type="text" >
                        
                        </asp:TextBox>
                    </div>


                </div>
                <div class="col-sm-4 ">
                    <label class="col-2 col-form-label">Type Of User</label>
                    <div class="col-10">
                        <div class="dropdown">
                            <asp:DropDownList runat="server" ID="DropDownList1" CssClass="dropbtn">
                                <asp:ListItem Value="Cloud User" >
                              
                                </asp:ListItem>
                                <asp:ListItem Value="Cloud Administraion" ></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
            </div>
       
        <div class="row">
            <div class="col-sm-8 ">
                <label class="col-2 col-form-label">Email</label>
                <div class="col-10">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" type="email" ></asp:TextBox>
                    
                </div>
            </div>
            <br />
        </div>
        <br />
        <div class="row">
            <div class="col-sm-8 ">
                <label class="col-2 col-form-label">Address</label>
                <div class="col-10">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" type="text" ></asp:TextBox>

                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3 col-xs-offset-1">
                    <label class="col-2 col-form-label">City</label>
                    <div class="col-10">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" type="text"></asp:TextBox>

                    </div>
                </div>
                <div class="col-sm-3">
                    <label class="col-2 col-form-label">State</label>
                    <div class="col-5">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" type="text" ></asp:TextBox>

                    </div>
                </div>

                <div class="col-sm-1">
                    <label class="col-2 col-form-label">Zip</label>
                    <div class="col-5">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" type="numbrt" ></asp:TextBox>

                    </div>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-sm-8 ">
                    <label class="col-2 col-form-label">Phone Number</label>
                    <div class="col-10">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" type="number" ></asp:TextBox>

                    </div>
                </div>

            </div>
        <br />
            <div class="row">
                <div class="col-sm-4 ">
                    <label class="col-2 col-form-label">Username</label>
                    <div class="col-10">
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" type="text" ></asp:TextBox>

                    </div>
                </div>
                
                <div class="col-sm-4 ">
                    <label class="col-2 col-form-label">Password</label>
                    <div class="col-10">
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" type="text" ></asp:TextBox>

                    </div>
                </div>
                           <div class="col-sm-2">
                    <div class="col-10">
                        <asp:TextBox ID="txtAPIAddCloudUser" runat="server" placeholder="API Key" CssClass="form-control" type="text" ></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="form-group">
                        <asp:Button runat="server" CssClass="btn btn-primary btn-md btn-block" Text="Sumbit" ID="Button1" OnClick="Button1_Click" />
                    </div>
                </div>


            </div>
        </div>
        <!--Cloud user edits their own account-->
            <div>
              <h1>Edit Cloud User Accounts As Cloud User</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GvCloudAccounts_RowCancelingEdit" OnRowDeleting="GvCloudAccounts_RowDeleting" OnRowEditing="GvCloudAccounts_RowEditing" OnRowUpdating="GvCloudAccounts_RowUpdating">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
               
                
                 <asp:CommandField ButtonType="Button" HeaderText="Edit Account" ShowEditButton="true" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete Account" ShowDeleteButton="true" />

            </Columns>
        </asp:GridView>
        </div>
      

        
         <!--add modify  delete accoumnt-->
        <div>
              <h1>Edit Cloud User Accounts As Administrator</h1>
        <asp:GridView ID="GvCloudAccounts" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GvCloudAccounts_RowCancelingEdit" OnRowDeleting="GvCloudAccounts_RowDeleting" OnRowEditing="GvCloudAccounts_RowEditing" OnRowUpdating="GvCloudAccounts_RowUpdating">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
                <asp:BoundField DataField="UserID" HeaderText="UserName" />
               
                
                 <asp:CommandField ButtonType="Button" HeaderText="Edit Account" ShowEditButton="true" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete Account" ShowDeleteButton="true" />

            </Columns>
        </asp:GridView>
        </div>
      

        </div>
    </form>
</body>
</html>

