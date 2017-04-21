using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class RequestAndTestWebS : System.Web.UI.Page
    {
        static String userNemFilesearch;
        static String userNemFilesearchIcon;
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        CloudWebS pxy2 = new CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
                gvEditUserByAdmin.DataBind();
                gvUserEditUser.DataSource = pxy.GetAllUsers();
                gvUserEditUser.DataBind();
                ddlDeleteUser.DataSource = pxy.GetAllUsers();
                ddlDeleteUser.DataTextField = "name";
                ddlDeleteUser.DataValueField = "username";
                ddlDeleteUser.DataBind();
                GvFiles.Visible = false;
                //GvCloudAccounts.Visible = false;
            }
        }



        protected void btnGetAPIKey_Click(object sender, EventArgs e)
        {
            ///call web serveric toreturn api key 
            ///
            String username = txtUserName.Text;


            String apiKey = "";
            apiKey = pxy.AssignWebServiceAPI(username);
            if (apiKey == null)
            {
                ATLAccountFailure.Visible = true;

            }
            else
            {
                ATLSuccessAlert.Visible = true;
                TxtAPIKey.Text = apiKey;
            }

        }
        public void GenerateFileGridView()
        {
            DataSet set = new DataSet();
            set = pxy.GetFilesByUser(txtuserNameGetAllFiles.Text);
            GvFiles.DataSource = set;
            GvFiles.DataBind();
            GvFiles.Visible = true;
        }
        protected void GvFiles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvFiles.EditIndex = -1;
            GenerateFileGridView();
        }

        protected void GvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            //get the row upload file
            String username = userNemFilesearch;
            float size = Convert.ToSingle(GvFiles.Rows[row].Cells[2].Text);
            String filename = GvFiles.Rows[row].Cells[0].Text;
            //call funtion to do update
            String results = "";
            results = pxy.DeleteFile(username, filename, size);
            lblfileListMessage.Text = results;
            lblfileListMessage.ForeColor = System.Drawing.Color.Green;
            //regenerate gridview
            GvFiles.EditIndex = -1;
            GenerateFileGridView();

        }

        protected void GvFiles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvFiles.EditIndex = e.NewEditIndex;
            GenerateFileGridView();
        }

        protected void GvFiles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int row = e.RowIndex;
            //get the row upload file
            FileUpload uploader = (FileUpload)GvFiles.Rows[row].FindControl("fileUploadGV");
            if (uploader.HasFile)
            {
                //file web object 
                WebS.FileInfoWS objfile = new WebS.FileInfoWS();
                //fiile length 
                int SizeFile = uploader.PostedFile.ContentLength;
                //file byte array
                byte[] FileDataByteArray = new byte[SizeFile];
                // inout data from the fileupload control into the byte array
                uploader.PostedFile.InputStream.Read(FileDataByteArray, 0, SizeFile);
                //objfile.File =
                // get file nmae os selected file
                //   String fileName = uploader.PostedFile.FileName;
                String fileName = GvFiles.Rows[row].Cells[0].Text;

                objfile.FileName = fileName;
                objfile.FileSize = SizeFile;

                //establishh file extension to get the type
                String fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();
                objfile.FileType = fileExtension;
                objfile.UploadDate = (DateTime.Now.ToShortDateString()).ToString();
                objfile.Username = userNemFilesearch;
                objfile.File = FileDataByteArray;

                //call funtion to do update
                String results = "";
                results = pxy.UpDateFile(objfile);
                lblfileListMessage.Text = results;
                lblfileListMessage.ForeColor = System.Drawing.Color.Green;
                //regenerate gridview
                GvFiles.EditIndex = -1;
                GenerateFileGridView();

            }
            else
            {
                GvFiles.EditIndex = -1;
                lblfileListMessage.Text = "Not file was selected";
                lblfileListMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GvCloudAccounts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvFiles.EditIndex = -1;
            GenerateFileGridView();
        }

        protected void gvEditUserByAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //gvEditUserByAdmin.EditIndex = e.RowIndex;
            //pxy.de
            //gvEditUserByAdmin.DataBind();
        }

        protected void GvCloudAccounts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {

            if (BtnFileUpload.HasFile)
            {
                //file web object 
                WebS.FileInfoWS objfile = new WebS.FileInfoWS();
                //fiile length 
                int SizeFile = BtnFileUpload.PostedFile.ContentLength;
                //file byte array
                byte[] FileDataByteArray = new byte[SizeFile];
                // inout data from the fileupload control into the byte array
                BtnFileUpload.PostedFile.InputStream.Read(FileDataByteArray, 0, SizeFile);
                //objfile.File =
                // get file lenggth
                String fileName = BtnFileUpload.PostedFile.FileName;
                objfile.FileName = fileName;
                objfile.FileSize = SizeFile;
                objfile.File = FileDataByteArray;
                //establishh file extension to get the type
                String fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();
                objfile.FileType = fileExtension;
                objfile.UploadDate = (DateTime.Now.ToShortDateString()).ToString();
                objfile.Username = txtAccountUsername.Text;
                //check to see what type of file it is 
                if (fileExtension == ".jpg" || fileExtension == ".mp3" || fileExtension == ".pdf" || fileExtension == ".png" || fileExtension == ".pptx" || fileExtension == ".docx")
                {
                    //call method to serialze and store file 
                    String ResultFIleUpload = "";
                    ResultFIleUpload = pxy.UploadFile(txtApiKeyFileupload.Text, objfile, txtAccountUsername.Text);

                    if (ResultFIleUpload == "")
                    {
                        lblAddfile.Visible
                            = true;
                        lblAddfile.Text = ResultFIleUpload;
                    }
                    if (ResultFIleUpload == "File not uploaded Succesfully" || ResultFIleUpload == "Not enough free storage to upload file" || ResultFIleUpload == "API Key not found.")
                    {
                        lblAddfile.Visible
                            = true;
                        lblAddfile.Text = ResultFIleUpload;
                    }
                    else
                    {
                        lblAddfile.Visible = true;
                        lblAddfile.ForeColor = System.Drawing.Color.Green;
                        lblAddfile.Text = "File Successfully Uploaded";
                        //change icon

                        ImgFileIcon.ImageUrl = ResultFIleUpload;

                    }

                }



                //show iumage icon ImageUr
                //ImageUrl
            }





        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void txtuserNameGetAllFiles_TextChanged(object sender, EventArgs e)
        {
            //show grid view with files
            String username = txtuserNameGetAllFiles.Text;
            userNemFilesearch = username;
            GenerateFileGridView();

        }

        protected void gvEditUserByAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEditUserByAdmin.EditIndex = e.NewEditIndex;
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.DataBind();
        }

        protected void gvEditUserByAdmin_RowUpdating(object sender, GridViewEditEventArgs e)
        {
            //pxy.EditUserByAdmin(gvEditUserByAdmin, e.RowIndex);
            //gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            //gvEditUserByAdmin.EditIndex = -1;
            //gvEditUserByAdmin.DataBind();
        }

        protected void gvEditUserByAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvEditUserByAdmin_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            pxy2.EditUserByAdmin(gvEditUserByAdmin, e.RowIndex);
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.EditIndex = -1;
            gvEditUserByAdmin.DataBind();

        }

        protected void gvEditUserByAdmin_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.DataBind();

        }

        protected void gvEditUserByAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEditUserByAdmin.EditIndex = -1;
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.DataBind();
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = ddlDeleteUser.SelectedItem.Value;

            pxy.DeleteUser(username);

            ddlDeleteUser.DataBind();
        }

        protected void GvShowaLLfiLESwITHiCON_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvShowaLLfiLESwITHiCON.EditIndex = -1;
            GenerateGvShowaLLfiLESwITHiCONGridView();
        }

        protected void GvShowaLLfiLESwITHiCON_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            //get the row upload file
            String username = userNemFilesearchIcon;
            float size = Convert.ToSingle(GvShowaLLfiLESwITHiCON.Rows[row].Cells[2].Text);
            String filename = GvShowaLLfiLESwITHiCON.Rows[row].Cells[0].Text;
            //call funtion to do update
            String results = "";
            results = pxy.DeleteFile(username, filename, size);
            lblfileListMessage.Text = results;
            lblfileListMessage.ForeColor = System.Drawing.Color.Green;
            //regenerate gridview
            GvShowaLLfiLESwITHiCON.EditIndex = -1;
            GenerateGvShowaLLfiLESwITHiCONGridView();

        }

        protected void GvShowaLLfiLESwITHiCON_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int row = e.RowIndex;
            //get the row upload file
            FileUpload uploader = (FileUpload)GvShowaLLfiLESwITHiCON.Rows[row].FindControl("fileUploadGV1");
            if (uploader.HasFile)
            {
                //file web object 
                WebS.FileInfoWS objfile = new WebS.FileInfoWS();
                //fiile length 
                int SizeFile = uploader.PostedFile.ContentLength;
                //file byte array
                byte[] FileDataByteArray = new byte[SizeFile];
                // inout data from the fileupload control into the byte array
                uploader.PostedFile.InputStream.Read(FileDataByteArray, 0, SizeFile);
                //objfile.File =
                // get file nmae os selected file
                //   String fileName = uploader.PostedFile.FileName;
                String fileName = GvShowaLLfiLESwITHiCON.Rows[row].Cells[0].Text;

                objfile.FileName = fileName;
                objfile.FileSize = SizeFile;

                //establishh file extension to get the type
                String fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();
                objfile.FileType = fileExtension;
                objfile.UploadDate = (DateTime.Now.ToShortDateString()).ToString();
                objfile.Username = userNemFilesearchIcon;
                objfile.File = FileDataByteArray;

                //call funtion to do update
                String results = "";
                results = pxy.UpDateFile(objfile);
                lblfileListMessage.Text = results;
                lblfileListMessage.ForeColor = System.Drawing.Color.Green;
                //regenerate gridview
                GvShowaLLfiLESwITHiCON.EditIndex = -1;
                GenerateGvShowaLLfiLESwITHiCONGridView();

            }
            else
            {
                GvShowaLLfiLESwITHiCON.EditIndex = -1;
                lblfileListMessage.Text = "Not file was selected";
                lblfileListMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GvShowaLLfiLESwITHiCON_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvShowaLLfiLESwITHiCON.EditIndex = e.NewEditIndex;
            GenerateGvShowaLLfiLESwITHiCONGridView();
        }

        protected void txtGetAllFilesicon_TextChanged(object sender, EventArgs e)
        {
            //show grid view with files
            String username = txtGetAllFilesicon.Text;
            userNemFilesearchIcon = username;
            GenerateGvShowaLLfiLESwITHiCONGridView();
        }

        public void GenerateGvShowaLLfiLESwITHiCONGridView()
        {
            DataSet set = new DataSet();
            set = pxy.GetFilesByUser(txtuserNameGetAllFiles.Text);
            GvShowaLLfiLESwITHiCON.DataSource = set;
            GvShowaLLfiLESwITHiCON.DataBind();
            ///
            DataSet set1 = new DataSet();
            set1 = pxy2.GetFilesByIcon(userNemFilesearchIcon);
            ///use table to asign
            ///          
            //Image img = (Image)GvShowaLLfiLESwITHiCON.Rows[i].FindControl["gvIMage"];
            for (int i = 0; i < set1.Tables[0].Rows.Count; i++)
            {
                Image img = (Image)GvShowaLLfiLESwITHiCON.Rows[i].FindControl("gvIMage");
                img.ImageUrl = set1.Tables[0].Rows[i].ToString();
            }


            GvShowaLLfiLESwITHiCON.Visible = true;
        }

        //Edit your own user information. This would be specific to the user that is logged in.
        protected void gvUserEditUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUserEditUser.EditIndex = -1;
            gvUserEditUser.DataSource = pxy.GetAllUsers();
            gvUserEditUser.DataBind();
        }

        protected void gvUserEditUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUserEditUser.EditIndex = e.NewEditIndex;
            gvUserEditUser.DataSource = pxy.GetAllUsers();
            gvUserEditUser.DataBind();
        }

        protected void gvUserEditUser_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            gvUserEditUser.DataSource = pxy.GetAllUsers();
            gvUserEditUser.DataBind();
        }

        protected void gvUserEditUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            pxy2.UserEditUser(gvUserEditUser, e.RowIndex);
            gvUserEditUser.DataSource = pxy.GetAllUsers();
            gvUserEditUser.EditIndex = -1;
            gvUserEditUser.DataBind();
        }
    }
}

