using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class AppMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check to see if user is loged in

                if (Session["login"]== null)
                {

                    //redirect user to login page 
                    ATLAccountFailure.Visible = true;
                   // show error message 
                    
                
                }
                else if  (Session["login"].ToString() == "Loged in")
                {
                    //show page content
                }
            }
        }
    }
}