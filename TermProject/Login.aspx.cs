using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Utilities;
using WebSvc;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        CloudWebS pxy2 = new CloudWebS();
        HttpCookie UserIdCookie = new HttpCookie("LoginIDCookie");
        HttpCookie cookie;
        Byte[] passwordBytes;
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["LoginIDCookie"] != null)
            {
                cookie = Request.Cookies["LoginIDCookie"];
                txtUserName.Text = cookie.Values["loginID"].ToString();
                if (cookie.Values["password"] != null) { 
                    txtPassword.Text = DecryptPassword();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != " " && txtPassword.Text != " ")
            {
                //cookie is stored on client machine
                if (chkRememberMe.Checked == true)
                {
                    //HttpCookie UserIdCookie = new HttpCookie("LoginIDCookie");
                    UserIdCookie.Values["loginID"] = txtUserName.Text;
                    EncryptPassword();
                    UserIdCookie.Expires = new DateTime(2025, 1, 1);
                    Response.Cookies.Add(UserIdCookie);



                }
                if (pxy2.GetUserActive(txtUserName.Text) == "yes")
                {
                    //authiticate login info
                    if (VerifyAccount(txtUserName.Text, txtPassword.Text))
                    {
                        //show success allert
                        ATLSuccessAlert.Visible = true;
                        //assign session key to reteive as user moves through the application
                        Session["login"] = txtUserName.Text;
                        //redirect to main page
                        if (pxy2.GetAccountType(txtUserName.Text) == "Cloud User")
                        {
                            Response.Redirect("CloudUser.aspx");
                        }
                        if (pxy2.GetAccountType(txtUserName.Text) == "Cloud Administrator")
                        {
                            Response.Redirect("CloudAdministrator.aspx");
                        }
                        if (pxy2.GetAccountType(txtUserName.Text) == "Super Admin")
                        {
                            Response.Redirect("SuperAdmin.aspx");
                        }
                        //Response.Redirect("AppMainPage.aspx");
                    }
                    else
                    {
                        ATLAccountFailure.Visible = true;
                    }
                }
                else if (pxy2.GetUserActive(txtUserName.Text) == "no")
                {
                    lblInactive.Text = "Account inactive";
                }
            }
                //authiticate login info
                if (VerifyAccount(txtUserName.Text, txtPassword.Text))
                {
                    //show success allert
                    ATLSuccessAlert.Visible = true;
                    //assign session key to reteive as user moves through the application
                    Session["login"] = txtUserName.Text;
                    //redirect to main page
                    if (pxy2.GetAccountType(txtUserName.Text) == "Cloud User" )
                    {
                        pxy.UpDateuSERObject(txtUserName.Text);
                        Response.Redirect("CloudUser.aspx");
                    }
                    if (pxy2.GetAccountType(txtUserName.Text) == "Cloud Administrator")
                    {
                        Response.Redirect("CloudAdministrator.aspx");
                    }
                    //Response.Redirect("AppMainPage.aspx");
                }
                else
                {
                    ATLAccountFailure.Visible = true;
                }
            }
            else
            {
                txtUserName.Text = "Required";
                txtPassword.Text = "Required";
            }


        }
        public Boolean VerifyAccount(String username, String password)
        {
            if (pxy.ConfirmUserLogin(username, password))
            {
                return true;
            }
            else
                return false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            Response.Redirect("Registration.aspx");
        }

        public void EncryptPassword()
        {
            String password = txtPassword.Text;
            String encryptedPassword;
            UTF8Encoding encoder = new UTF8Encoding();

            passwordBytes = encoder.GetBytes(password);

            RijndaelManaged encryption = new RijndaelManaged();
            MemoryStream stream = new MemoryStream();
            CryptoStream encryptionStream = new CryptoStream(stream, encryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            encryptionStream.Write(passwordBytes, 0, passwordBytes.Length);
            encryptionStream.FlushFinalBlock();

            stream.Position = 0;
            Byte[] encryptedArray = new Byte[stream.Length];
            stream.Read(encryptedArray, 0, encryptedArray.Length);

            stream.Close();
            encryptionStream.Close();

            encryptedPassword = Convert.ToBase64String(encryptedArray);

            UserIdCookie.Values["password"] = encryptedPassword;
            Response.Cookies.Add(UserIdCookie);
        }

        public String DecryptPassword()
        {
            cookie = Request.Cookies["LoginIDCookie"];
            String encryptedPassword = cookie.Values["password"];
            UTF8Encoding encoder = new UTF8Encoding();

            Byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);
            Byte[] text;
            String password;

            RijndaelManaged encryption = new RijndaelManaged();
            MemoryStream stream = new MemoryStream();
            CryptoStream decryptionStream = new CryptoStream(stream, encryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            decryptionStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            decryptionStream.FlushFinalBlock();

            stream.Position = 0;
            text = new Byte[stream.Length];
            stream.Read(text, 0, text.Length);

            stream.Close();
            decryptionStream.Close();

            password = encoder.GetString(text);
            /////
            return password;
        }
    }
}