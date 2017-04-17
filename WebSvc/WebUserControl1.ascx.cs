using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace WebSvc
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        CloudWebS pxy = new CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        [Category("Misc")]
        public String fileType
        {
            get { return fileType; }
            set { fileType = value; }
        }
        [Category("Misc")]
        public String fileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        [Category("Misc")]
        public String username
        {
            get { return username; }
            set { username = value; }
        }
        [Category("Misc")]
        public String FileImage
        {
            get { return ImgUserControlFileIcon.ImageUrl; }
            set { ImgUserControlFileIcon.ImageUrl = value; }
        }

        [Category("Misc")]
        public DataSet FileDataSet {
            get { return FileDataSet; }
            set { FileDataSet = value; }
        }

        public override void DataBind()
        {

            //imgProduct.ImageUrl = "/images/" + productID + ".jpg";

            /*
            lblUsercontrolFileName.Text = fileName;
                LblUserControlFileType.Text = fileType;
            lblUserControlFileUPloadDate.Text =
            LblUserControlUserNamw.Text = username;
                LblUserCOontrolFileSize.Text =
                ImgUserControlFileIcon.ImageUrl = FileImage;
                */
               /* FileDataSet.Tables[]
            lblUsercontrolFileName.Text = fileName;
            LblUserControlFileType.Text = fileType;
            lblUserControlFileUPloadDate.Text =
            LblUserControlUserNamw.Text = username;
            LblUserCOontrolFileSize.Text =
            ImgUserControlFileIcon.ImageUrl = FileImage;
            */
        }

    }
}