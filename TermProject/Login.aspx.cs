using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Utilities;

namespace TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["LoginIDCookie"]!=null)
            {
                HttpCookie cookie=   Request.Cookies["LoginIDCookie"];
                txtUserName.Text = cookie.Values["loginID"].ToString();

               
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //cookie is stored on client machine
            if (chkRememberMe.Checked == true)
            {
                HttpCookie UserIdCookie = new HttpCookie("LoginIDCookie");
                UserIdCookie.Values["loginID"] = txtUserName.Text;
                UserIdCookie.Expires = new DateTime(2025, 1, 1);
                Response.Cookies.Add(UserIdCookie);

                

            }
            //authiticate login info
            if (VerifyAccount( txtUserName.Text,  txtPassword.Text))
            {
                //show success allert
                ATLSuccessAlert.Visible = true;
                //assign session key to reteive as user moves through the application
                Session["login"] = "Loged in";
                //redirect to main page
                Response.Redirect("AppMainPage.aspx");
            }
            else
            {
                ATLAccountFailure.Visible = true;
            }

           
        }
        public  Boolean VerifyAccount(String username, String password)
        {
            if (pxy.ConfirmUserLogin(username, password))
            {
                return true;
            }
            else
                return false;
        }
    }
}