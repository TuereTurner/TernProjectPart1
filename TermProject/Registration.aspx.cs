using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;

namespace TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        CloudWebS pxy2 = new CloudWebS();
        /// WebSvc.RestaurantSvc pxy = new WebSvc.RestaurantSvc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblBadUsername.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WebS.User user = new WebS.User();
            //store items in the opject 

            String name = txtName.Text;
            String typeofUser = drpTypeOfUser.SelectedValue;
            String Address = txtAddress.Text + " " + txtSate.Text + ", " + txtCity.Text + " " + txtZip.Text;
            String email = txtEmail.Text;
            String phonenumber = txtPhoneNumber.Text;
            String password = txtPassword.Text;
            String username = txtUserName.Text;
            //assign values to object properties
            user.Name = name;
            user.TypeOfUser = typeofUser;
            user.Email = email;
            user.PhoneNumber = phonenumber;
            user.Password = password;
            user.Username = username;
            user.Address = Address;
            //return object to webservice
            if (pxy2.CheckDuplicateUsername(txtUserName.Text))
            {
                if (pxy.AddUser(user))
                {
                    ATLSuccessAlert.Visible = true;
                    //re direct to main page
                    Session["login"] = "Loged in";
                    //add cookkie if checked 
                    //cookie is stored on client machine
                    if (chkStorecookies.Checked == true)
                    {
                        HttpCookie UserIdCookie = new HttpCookie("LoginIDCookie");
                        UserIdCookie.Values["loginID"] = txtUserName.Text;
                        UserIdCookie.Expires = new DateTime(2025, 1, 1);
                        Response.Cookies.Add(UserIdCookie);
                       
                        int x;
                        x = pxy.InsertuSERObject(username);
                        
                    }
                    Response.Redirect("Login.aspx");
                    //add to user object 
                    pxy.InsertuSERObject(username);
                }
            }
            else
            {
                lblBadUsername.Visible = true;
                ATLAccountFailure.Visible = true;
            }

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}