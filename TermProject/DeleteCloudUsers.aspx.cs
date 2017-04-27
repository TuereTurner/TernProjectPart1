using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class DeleteCloudUsers : System.Web.UI.Page
    {
        string username;
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
                ddlDeleteCloudUsers.DataSource = pxy2.GetCloudUsers();
                ddlDeleteCloudUsers.DataTextField = "name";
                ddlDeleteCloudUsers.DataValueField = "username";
                ddlDeleteCloudUsers.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            pxy2.DeleteUser(ddlDeleteCloudUsers.SelectedValue);
            ddlDeleteCloudUsers.DataSource = pxy2.GetCloudUsers();
            ddlDeleteCloudUsers.DataBind();
        }
    }
}