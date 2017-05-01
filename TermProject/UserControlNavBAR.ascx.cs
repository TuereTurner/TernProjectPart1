using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class UserControlNavBAR : System.Web.UI.UserControl
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //
            String username = Session["login"].ToString();
            pxy.UpDateuSERObject(username);   
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}