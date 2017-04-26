using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class EditUserByUser : System.Web.UI.Page
    {
        String username;
        CloudWebS pxy2 = new CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Registration.aspx");
            }
            else
            {
                username = Session["login"].ToString();
            }
            if (!IsPostBack)
            {
                gvEditUser.DataSource = pxy2.GetSpecificUser(username);
                gvEditUser.DataBind();
            }
        }
        protected void gvEditUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEditUser.EditIndex = -1;
            gvEditUser.DataSource = pxy2.GetSpecificUser(username);
            gvEditUser.DataBind();
        }

        protected void gvUserEditUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEditUser.EditIndex = e.NewEditIndex;
            gvEditUser.DataSource = pxy2.GetSpecificUser(username);
            gvEditUser.DataBind();
        }

        protected void gvUserEditUser_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            gvEditUser.DataSource = pxy2.GetSpecificUser(username);
            gvEditUser.DataBind();
        }

        protected void gvUserEditUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            pxy2.UserEditUser(gvEditUser, e.RowIndex, username);
            gvEditUser.DataSource = pxy2.GetSpecificUser(username);
            gvEditUser.EditIndex = -1;
            gvEditUser.DataBind();
        }
    }
}