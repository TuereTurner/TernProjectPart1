using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class ViewOrAnswerQuestions : System.Web.UI.Page
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
                gvQuestions.DataSource = pxy2.GetQuestions();
                gvQuestions.DataBind();
            }
        }

        protected void btnAskQuestion_Click(object sender, EventArgs e)
        {

        }

        protected void btnAnswerQuestion_Click(object sender, EventArgs e)
        {
            if(pxy2.AnswerQuestion(username, txtAnswer.Text, Convert.ToInt32(txtQuestionsID.Text)))
            {
                gvQuestions.DataSource = pxy2.GetQuestions();
                gvQuestions.DataBind();
            }
        }
    }
}