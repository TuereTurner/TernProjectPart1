using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TermProject
{
    public partial class File_Storage_Restore : System.Web.UI.Page
    {
    static    WebS.CloudWebS pxy = new WebS.CloudWebS();
        static String username;
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

                username  = Session["login"].ToString();
                    String s = Session["login"].ToString();

                    GenerateRestoredFiles();
                    GenerateDeletedFiles();
                }
            }
        }

        public  void GenerateRestoredFiles()
        {
            DataSet set = new DataSet();
           set= pxy.SelectOldFileVserion(username);
            GridViewVersionRecover.DataSource = set;
            GridViewVersionRecover.DataBind();

        }
        public void GenerateDeletedFiles()
        {
            DataSet set = new DataSet();
            set = pxy.SelectAllDeletedFiles(username);
            GridVDeletedFiles.DataSource = set;
            GridVDeletedFiles.DataBind();

        }

   

        protected void BTNDeletedFileReover_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridVDeletedFiles.Rows.Count; i++)
            {
                CheckBox box = new CheckBox();
                 box = (CheckBox)GridVDeletedFiles.Rows[i].FindControl("chkGridDelete");

                if (box.Checked)
                {
                    WebS.FileInfoWS file = new WebS.FileInfoWS();
                    String filename = GridVDeletedFiles.Rows[i].Cells[1].Text;
                    file.FileName = filename;
                    String x = GridVDeletedFiles.Rows[i].Cells[4].Text;
                    file.FileSize = Convert.ToSingle(GridVDeletedFiles.Rows[i].Cells[4].Text);
                    file.FileType = GridVDeletedFiles.Rows[i].Cells[3].Text;
                    //get file byte array
                    DataSet byteset = pxy.SelectOneDELETEDFFile(username, filename);

                    byte[] filebyte = (byte[])(byteset.Tables[0].Rows[0]["file"]);
                    file.File = filebyte;
                    String results = "";
                    results = pxy.UploadFile("6477544441684327", file, username);
                    if (results == "")
                    {
                        lbldelectedfilerecover.Text = "The file was not recovered";

                    }else
                    {
                        lbldelectedfilerecover.Text = "File Recovered";
                        //delete from deleted table

                        pxy.DeleteFromDELETEDFFile(username, filename);
                        GenerateDeletedFiles();
                    }
                  
                }

            }
        }

        protected void btnResoreVerson_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewVersionRecover.Rows.Count; i++)
            {
                CheckBox box = new CheckBox();
                box = (CheckBox)GridViewVersionRecover.Rows[i].FindControl("chkGridVerison");

                if (box.Checked)
                {
                    WebS.FileInfoWS file = new WebS.FileInfoWS();
                    String filename = GridViewVersionRecover.Rows[i].Cells[1].Text;
                    file.FileName = filename;
                    String x = GridViewVersionRecover.Rows[i].Cells[4].Text;
                    file.FileSize = Convert.ToSingle(GridViewVersionRecover.Rows[i].Cells[5].Text);
                    file.FileType = GridViewVersionRecover.Rows[i].Cells[4].Text;
                    //get file byte array
                    DataSet byteset = pxy.SelectOneRecoveredFFile(username, filename);

                    byte[] filebyte = (byte[])(byteset.Tables[0].Rows[0]["file"]);
                    file.File = filebyte;
                    String results = "";
                    results = pxy.UploadFile("6477544441684327", file, username);
                    if (results == "")
                    {
                        lblrecoverfile.Text = "The file was not recovered";

                    }
                    else
                    {
                        lblrecoverfile.Text = "File Recovered";
                        //delete from deleted table

                        pxy.DeleteFromRecoveredFFile(username, filename);
                        GenerateRestoredFiles();
                    }

                }

            }
        }
    }
}