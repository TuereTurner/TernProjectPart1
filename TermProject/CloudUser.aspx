<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="styleSheet.css" />
</head>
<body>
    <div class="alert alert-warning" id="ATLAccountFailure" runat="server" visible="false">
        <strong>Login-In Required to view this Page !</strong>
        <a href="Login.aspx">Log-In</a>
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

        <h1>User Cloud Home</h1>

        <hr />

        <h2 id="fileUpload">File Upload</h2>
        <div runat="server" id="divplaceholder"></div>

        <div class="Stylediv" style="background-color: aliceblue; align-content: center; float: left; padding-right: inherit; margin-right: 5px; margin-left: -10px; padding-left: 0px; padding-top: 0px; width: 753px; height: 36px;">
            <asp:Button runat="server" Text="Upload File" ID="btnUpload" CssClass="button" OnClick="btnUpload_Click" Height="51px" Width="187px" />
            <asp:Label runat="server" ID="lblAddfile" ForeColor="Red" Visible="false"></asp:Label>
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
       
        <h1>Files </h1>
        <hr />
        <h3 id="cloudFolder">Cloud Folder</h3>
        <asp:Label ID="lblUsage" runat="server" Text=""></asp:Label>
        <div class="Stylediv">
            
            <asp:Label runat="server" ID="lblfileListMessage"></asp:Label>
            <asp:Label runat="server" ID="LblviewfILESMesage"></asp:Label>

            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="background-color:aliceblue;">
                <ContentTemplate>
                    <asp:GridView ID="GvShowaLLfiLESwITHiCON" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GvShowaLLfiLESwITHiCON_RowCancelingEdit" OnRowDeleting="GvShowaLLfiLESwITHiCON_RowDeleting" OnRowEditing="GvShowaLLfiLESwITHiCON_RowEditing" OnRowUpdating="GvShowaLLfiLESwITHiCON_RowUpdating" OnSelectedIndexChanged="GvShowaLLfiLESwITHiCON_SelectedIndexChanged" Style="margin-left: 50px" Width="463px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="White" />
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
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <!-- storage-->
        <div>
            <div>
                <asp:LinkButton runat="server" OnClick="Unnamed_Click" Text="Download File"></asp:LinkButton>
            </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>

        <br />
        <br />
        <br />
        <br />
        <br />

    </form>
</body>
</html>
