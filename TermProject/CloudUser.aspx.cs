using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using WebSvc;
using System.Collections;
using System.Web.Configuration;
using File;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TermProject
{
    public partial class CloudUser : System.Web.UI.Page
    {


        static String username;
        WebS.CloudWebS pxy = new WebS.CloudWebS();
     //   CloudWebS pxyy = new CloudWebS();
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
                else if (Session["login"].ToString() != null)
                {

                    //show page content
                    username = Session["login"].ToString();
                    //txtGetAllFilesicon.Text = Session["login"].ToString();
                    //update
                   pxy.UpDateuSERObject(username);

                    GenerateUSEROHJECTGridView();

                    divplaceholder.Visible = false;

                    GenerateGvShowaLLfiLESwITHiCONGridView();
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

            GenerateGvShowaLLfiLESwITHiCONGridView();
        }
        public void GenerateGvShowaLLfiLESwITHiCONGridView()
        {
            DataSet set = new DataSet();
            set = pxy.GetFilesByUser(username); try
            {
               
                GvShowaLLfiLESwITHiCON.DataSource = set;
                GvShowaLLfiLESwITHiCON.DataBind();
            }
            catch(Exception e)
            {
                
            }
            ///

            DataSet set1 = new DataSet();
            set1 = pxy.GetFilesByIcon(username);

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
        public void GenerateUSEROHJECTGridView()
        {
            pxy.UpDateuSERObject(username);

            int wi = pxy.UpDateuSERObject(username);
            DataSet set = new DataSet();
            set = pxy.sELECTuSERObject(username);
            GridViewCloudObj.DataSource = set;
            GridViewCloudObj.DataBind();
            ///

            DataSet set1 = new DataSet();
            set1 = pxy.GetFilesByIcon(username);

            ///use table to asign
            ///          
            DataTable table = set1.Tables["Icons"];

            //Image img = (Image)GvShowaLLfiLESwITHiCON.Rows[i].FindControl["gvIMage"];
            for (int i = 0; i < set1.Tables["Icons"].Rows.Count; i++)
            {
                Image img = (Image)GridViewCloudObj.Rows[i].FindControl("gvIMage");


                img.ImageUrl = table.Rows[i].ItemArray[0].ToString();

                String g = table.Rows[i].ItemArray.ToString();
            }


            GridViewCloudObj.Visible = true;
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
            GenerateUSEROHJECTGridView();
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
                objfile.Username = username;
                objfile.File = FileDataByteArray;

                //call funtion to do update
                String results = "";
                results = pxy.UpDateFile(objfile, objfile.FileName + " " + DateTime.Today.ToShortDateString());
                lblfileListMessage.Text = results;
                lblfileListMessage.ForeColor = System.Drawing.Color.Green;
                //regenerate gridview
                GvShowaLLfiLESwITHiCON.EditIndex = -1;
                GenerateGvShowaLLfiLESwITHiCONGridView();
                GenerateUSEROHJECTGridView();
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
            int row = GvShowaLLfiLESwITHiCON.SelectedRow.RowIndex;
            Button btnDownload = (Button)GvShowaLLfiLESwITHiCON.SelectedRow.FindControl("btnGridDownload");
            String filename = GvShowaLLfiLESwITHiCON.Rows[row].Cells[0].Text;
            ///download file
            ///fet the dataset
            //
         //   DataSet set = new DataSet();
          //  set = pxy.SelectOneFFile(username, filename);
          //  String type = set.Tables[0].Rows[0]["fileType"].ToString();
            DataSet byteset = pxy.SelectOneFFile(username, filename);

            byte[] filebyte = (byte[])(byteset.Tables[0].Rows[0]["file"]);
            BinaryFormatter deSerializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream(filebyte);

            FileInfoWS filebytesdeserialized = (FileInfoWS)deSerializer.Deserialize(memStream);

            filebyte = filebytesdeserialized.File;

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.OutputStream.Write(filebyte, 0, filebyte.Length);
            Response.Flush();

            GenerateUSEROHJECTGridView();


        }

        protected void btnUpload_Click(object sender, EventArgs e)
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
                objfile.Username = username;
                //check to see what type of file it is 
                if ( fileExtension == ".pdf" || fileExtension == ".xlsx" || fileExtension == ".csv"|| fileExtension == ".pptx" || fileExtension == ".docx")
                {
                    //call method to serialze and store file 
                    String ResultFIleUpload = "";
                    ResultFIleUpload = pxy.UploadFile("6477544441684327", objfile, username);

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

                        // ImgFileIcon.ImageUrl = ResultFIleUpload;


                        //pop up user control

                        // Register the ASCX control with the page and typecast it to the appropriate class ProductDisplay
                        WebUserControl1 ctrl = (WebUserControl1)LoadControl("WebUserControlShowFile.ascx");

                        // Set properties for the ProductDisplay object
                        ctrl.FileImage = ResultFIleUpload;
                        ctrl.fileName = fileName;
                        ctrl.UserName = username;

                        ctrl.DataBind();

                        // Add the control object to the WebForm's Controls collection
                        Form.Controls.Add(ctrl);
                        divplaceholder.Controls.Clear();

                        divplaceholder.Controls.Add(ctrl);
                        GenerateGvShowaLLfiLESwITHiCONGridView();
                        GenerateUSEROHJECTGridView();
                        divplaceholder.Visible = true;

                    }

                }



                //show iumage icon ImageUr
                //ImageUrl
            }




        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }




    }
}