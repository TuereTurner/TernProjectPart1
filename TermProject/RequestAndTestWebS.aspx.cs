using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class RequestAndTestWebS : System.Web.UI.Page
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void btnGetAPIKey_Click(object sender, EventArgs e)
        {
            ///call web serveric toreturn api key 
            ///
            String username = txtUserName.Text;


            String apiKey = "";
            apiKey = pxy.AssignWebServiceAPI(username);
            if (apiKey == null)
            {
                ATLAccountFailure.Visible = true;
               
            }
            else
            {
                ATLSuccessAlert.Visible = true;
                TxtAPIKey.Text = apiKey;
            }

        }

        protected void gvFiles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvFiles_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvFiles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GvCloudAccounts_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {

        }
    }
}