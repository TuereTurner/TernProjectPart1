using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TermProject
{
    public class Global : System.Web.HttpApplication
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
   

           
       
            

         

         
        
    }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            String username = Session["login"].ToString();
            pxy.UpDateuSERObject(username);
            Session.Abandon();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}