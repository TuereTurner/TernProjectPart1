using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class RequestAndTestWebS : System.Web.UI.Page
    {
         WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void gvFiles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvFiles_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvFiles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
                      ResultFIleUpload=  pxy.UploadFile(txtApiKeyFileupload.Text, objfile,txtAccountUsername.Text);

                        if (ResultFIleUpload == "")
                        {
                        lblAddfile.Visible
                            = true;
                        lblAddfile.Text = ResultFIleUpload;
                        }
                        if(ResultFIleUpload== "File not uploaded Succesfully"|| ResultFIleUpload== "Not enough free storage to upload file"|| ResultFIleUpload== "API Key not found.")
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
    }
}