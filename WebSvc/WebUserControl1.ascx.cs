﻿using System;
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
        public String UserName
        {
            get { return UserName; }
            set { UserName = value; }
        }
        [Category("Misc")]
        public String fileName
        {
            get { return fileName; }
            set { fileName = value; }
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

            ImgUserControlFileIcon.ImageUrl = FileImage;
            DataSet SET = new DataSet();

            SET = pxy.SelectOneFFile(UserName, fileName);

            String type = SET.Tables[0].Rows[0]["fileType"].ToString();
            String date = SET.Tables[0].Rows[0]["uploadDate"].ToString();
            float size =Convert.ToSingle( SET.Tables[0].Rows[0]["fileSize"].ToString());
            lblUsercontrolFileName.Text = fileName;
                LblUserControlFileType.Text = type ;
            lblUserControlFileUPloadDate.Text = date;
            LblUserControlUserNamw.Text = UserName;
            LblUserCOontrolFileSize.Text = size.ToString()+" Btyes";
                ImgUserControlFileIcon.ImageUrl = FileImage;

           
            //call web service

        }

    }
}