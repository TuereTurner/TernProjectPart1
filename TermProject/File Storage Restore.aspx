<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="File Storage Restore.aspx.cs" Inherits="TermProject.File_Storage_Restore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        h1{
            text-align:center;
            color:dodgerblue;
        }
        body{
            background-color:aliceblue;
            border:thick;
            border-color:white;
        }
         
        .button{
            background-color:white;
            font-size:20px;
            border-radius: 50%;
            color:deepskyblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <h1>Restore Deleted Files</h1>
        <asp:GridView ID="GridVDeletedFiles" runat="server" AutoGenerateColumns="false">
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:CheckBox runat="server" if="chkGridDelete"/>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="fileName" HeaderText="" />
               <asp:BoundField DataField="DateDeleted" HeaderText="" />
               <asp:BoundField DataField="fileType" HeaderText="" />
               <asp:BoundField DataField="fileSize" HeaderText="" />

           </Columns>
        </asp:GridView>
        <asp:Button runat="server" Text="Recover Deleted File" ID="BTNDeletedFileReover" CssClass="button"/>
    </div>
        <div>
        <h1>Restore Deleted Files</h1>
        <asp:GridView ID="GridViewVersionRecover" runat="server" AutoGenerateColumns="false">
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:CheckBox runat="server" if="chkGridDelete"/>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="fileName" HeaderText="" />
               <asp:BoundField DataField="DateReplaced" HeaderText="" />
               <asp:BoundField DataField="fileType" HeaderText="" />
               <asp:BoundField DataField="fileSize" HeaderText="" />

           </Columns>
        </asp:GridView>
             <asp:GridView ID="GvShowaLLfiLESwITHiCON" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="GvShowaLLfiLESwITHiCON_RowCancelingEdit" OnRowDeleting="GvShowaLLfiLESwITHiCON_RowDeleting" OnRowEditing="GvShowaLLfiLESwITHiCON_RowEditing" OnRowUpdating="GvShowaLLfiLESwITHiCON_RowUpdating" Width="463px" OnSelectedIndexChanged="txtGetAllFilesicon_TextChanged">
            <Columns>
                <asp:BoundField DataField="fileName" HeaderText="File Name" ReadOnly="true"/>
                <asp:BoundField DataField="fileType" HeaderText="File Type" ReadOnly="true" />
                <asp:BoundField DataField="fileSize" HeaderText="Size" ReadOnly="true"/>
                <asp:BoundField DataField="uploadDate" HeaderText="Upload date" ReadOnly="true"  />
                <asp:TemplateField HeaderText="UpdateFile to Newer Version">
                    <ItemTemplate>
                        <asp:Image runat="server" id="gvIMage"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdateFile to Newer Version">
                    <ItemTemplate>
                        <asp:FileUpload runat="server" ID="fileUploadGV1" />
                    </ItemTemplate>
                </asp:TemplateField>
                
           </Columns>
        </asp:GridView>
    </div>
    </div>
    </form>
</body>
</html>
