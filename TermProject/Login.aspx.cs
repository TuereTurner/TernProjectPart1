using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Utilities;
using WebSvc;

namespace TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        CloudWebS pxy2 = new CloudWebS();
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
            if (txtUserName.Text != " " && txtPassword.Text != " ")
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
                if (VerifyAccount(txtUserName.Text, txtPassword.Text))
                {
                    //show success allert
                    ATLSuccessAlert.Visible = true;
                    //assign session key to reteive as user moves through the application
                    Session["login"] = txtUserName.Text;
                    //redirect to main page
                    if(pxy2.GetAccountType(txtUserName.Text) == "Cloud User")
                    {
                        Response.Redirect("CloudUser.aspx");
                    }
                    if(pxy2.GetAccountType(txtUserName.Text) == "Cloud Administrator")
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
        public  Boolean VerifyAccount(String username, String password)
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
    }
}