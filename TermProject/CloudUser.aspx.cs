using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using WebSvc;
using File;
namespace TermProject
{
    public partial class CloudUser : System.Web.UI.Page
    {
        static String userNemFilesearch;
        static String userNemFilesearchIcon;
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check to see if user is loged in

                if (Session["login"] == null)
                {

                    //redirect user to login page 
                    ATLAccountFailure.Visible = true;
                    // show error message 
                    form1.Visible = false;

                }
                else if (Session["login"].ToString() !=null)
                {
                    //show page content

                    txtGetAllFilesicon.Text = Session["login"].ToString();
                 String s=   Session["login"].ToString();

                }
            }
        }

        protected void btnBuyMoreStorage_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyMoreStorage.aspx");
        }

        protected void btnAskQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AskQuestion.aspx");
        }

        protected void btnEditInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUserByUser.aspx");
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {

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
            set = pxy.GetFilesByUser(txtGetAllFilesicon.Text);
            GvShowaLLfiLESwITHiCON.DataSource = set;
            GvShowaLLfiLESwITHiCON.DataBind();
            ///
           
            DataSet set1 = new DataSet();
            set1 = pxy.GetFilesByIcon(userNemFilesearchIcon);

            ///use table to asign
            ///          
            DataTable table = set1.Tables["Icons"];

            //Image img = (Image)GvShowaLLfiLESwITHiCON.Rows[i].FindControl["gvIMage"];
            for (int i = 0; i < set1.Tables["Icons"].Rows.Count; i++)
            {
                Image img = (Image)GvShowaLLfiLESwITHiCON.Rows[i].FindControl("gvIMage");


                img.ImageUrl = table.Rows[i].ItemArray[0].ToString();

                String g = table.Rows[i].ItemArray.ToString();
            }


            GvShowaLLfiLESwITHiCON.Visible = true;
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
            DataSet byteset = pxy.SelectOneFFile(username, filename);

            byte[] filebyte = (byte[])(byteset.Tables[0].Rows[0]["file"]);

           WebS.FileInfoWS file = new WebS.FileInfoWS();
           
            file.FileName = filename;
            file.File = filebyte;
            file.FileType = GvShowaLLfiLESwITHiCON.Rows[row].Cells[1].Text;
            file.FileSize = size;
            ///deletes file and storws on deleted file table
            ///
           
            
            pxy.DeleteFile(username, file);


            //results = pxy.DeleteFile(username, file);
            lblfileListMessage.Text = results;
            lblfileListMessage.ForeColor = System.Drawing.Color.Green;
            //regenerate gridview
            GvShowaLLfiLESwITHiCON.EditIndex = -1;
            GenerateGvShowaLLfiLESwITHiCONGridView();
        }

        protected void GvShowaLLfiLESwITHiCON_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvShowaLLfiLESwITHiCON.EditIndex = e.NewEditIndex;
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
                results = pxy.UpDateFile(objfile, objfile.FileName+" "+DateTime.Today.ToShortDateString());
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

        protected void GvShowaLLfiLESwITHiCON_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}