using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class CloudAdministrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEditCloudUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCloudUsers.aspx");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewOrAnswerQuestions.aspx");
        }
    }
}