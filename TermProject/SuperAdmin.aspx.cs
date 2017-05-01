using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class SuperAdmin : System.Web.UI.Page
    {
        String username;
        CloudWebS pxy2 = new CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] == null)
            {
                Response.Redirect("Registration.aspx");
            }
            else
            {
                username = Session["login"].ToString();
            }
            if (!IsPostBack)
            {
                ddlCloudAdministrators.DataSource = pxy2.GetCloudAdministrators();
                ddlCloudAdministrators.DataTextField = "name";
                ddlCloudAdministrators.DataValueField = "username";
                ddlCloudAdministrators.DataBind();
            }
        }

        protected void ddlCloudAdministrators_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvTransactions.DataSource = pxy2.GetTransactionsByUsername(ddlCloudAdministrators.SelectedValue);
            gvTransactions.DataBind();

        }
    }
}