using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class AskQuestion : System.Web.UI.Page
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
                gvQuestions.DataSource = pxy2.GetQuestions();
                gvQuestions.DataBind();
            }
        }

        protected void btnAskQuestion_Click(object sender, EventArgs e)
        {
            pxy2.AskQuestion(username, txtQuestion.Text);
            gvQuestions.DataSource = pxy2.GetQuestions();
            gvQuestions.DataBind();
        }
    }
}