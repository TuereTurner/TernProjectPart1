using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class CloudUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuyMoreStorage_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyMoreStorage.aspx");
        }

        protected void btnAskQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AskQuestion.aspx");
        }

        protected void btnEditInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUserByUser.aspx");
        }
    }
}