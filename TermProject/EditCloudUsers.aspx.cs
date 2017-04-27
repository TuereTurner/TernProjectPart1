using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class EditCloudUsers : System.Web.UI.Page
    {
        String adminUsername;
        CloudWebS pxy2 = new CloudWebS();
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Registration.aspx");
            }
            else
            {
                adminUsername = Session["login"].ToString();
            }
            if (!IsPostBack)
            {
                gvEditUserByAdmin.DataSource = pxy2.GetAllUsers();
                gvEditUserByAdmin.DataBind();
            }
        }

        protected void gvEditUserByAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvEditUserByAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEditUserByAdmin.EditIndex = e.NewEditIndex;
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.DataBind();
        }

        protected void gvEditUserByAdmin_RowUpdating(object sender, GridViewEditEventArgs e)
        {
            //pxy.EditUserByAdmin(gvEditUserByAdmin, e.RowIndex);
            //gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            //gvEditUserByAdmin.EditIndex = -1;
            //gvEditUserByAdmin.DataBind();
        }
        protected void gvEditUserByAdmin_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            String username = gvEditUserByAdmin.Rows[e.RowIndex].Cells[0].Controls[0].ToString();
            pxy2.EditUserByAdmin(gvEditUserByAdmin, e.RowIndex);
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.EditIndex = -1;
            gvEditUserByAdmin.DataBind();

        }

        protected void gvEditUserByAdmin_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.DataBind();

        }

        protected void gvEditUserByAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEditUserByAdmin.EditIndex = -1;
            gvEditUserByAdmin.DataSource = pxy.GetAllUsers();
            gvEditUserByAdmin.DataBind();
        }
    }
}