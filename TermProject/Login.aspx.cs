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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["LoginIDCookie"]!=null)
            {
                HttpCookie cookie=   Request.Cookies["LoginIDCookie"];
                txtUserName.Text = cookie.Values["LoginIDCookie"].ToString();
                txtUserName.Text = cookie.Values["LoginIDCookie"].ToString();
                txtUserName.Text = cookie.Values["LoginIDCookie"].ToString();

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (chkRememberMe.Checked == true)
            {
                HttpCookie UserIdCookie = new HttpCookie("LoginIDCookie");
                UserIdCookie.Values["loginID"] = txtUserName.Text;
                UserIdCookie.Expires = new DateTime(2025, 1, 1);
                Response.Cookies.Add(UserIdCookie);

                

            }
           
        }
    }
}