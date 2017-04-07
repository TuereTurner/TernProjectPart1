using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Users;
using System.Collections;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace WebSvc
{
    /// <summary>
    /// Summary description for RestaurantSvc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CloudWebS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Boolean AddUser(User newUser)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            if (newUser != null)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddUser";

                objCommand.Parameters.AddWithValue("@username", newUser.Username);
                objCommand.Parameters.AddWithValue("@password", newUser.Password);
                objCommand.Parameters.AddWithValue("@typeOfUSer", newUser.TypeOfUser);
                objCommand.Parameters.AddWithValue("@name", newUser.Name);
                objCommand.Parameters.AddWithValue("@email", newUser.Email);
                objCommand.Parameters.AddWithValue("@address", newUser.Address);
                objCommand.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);

                objDB.DoUpdateUsingCmdObj(objCommand);
                return true;
            }
            else
                return false;
        }
        [WebMethod]
        public Boolean ConfirmUserLogin(String Username, String password)
        {
            //get dataset with all user login info

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //set parameters for stored prosdure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserBypassword_Name_Verify";

            objCommand.Parameters.AddWithValue("@userName", Username);
            objCommand.Parameters.AddWithValue("@password", password);

            SqlParameter output = new SqlParameter("@count", 0);
            output.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(output);

            //need data set to check password and login
            objDB.GetDataSetUsingCmdObj(objCommand);
            int count;
            count = int.Parse(objCommand.Parameters["@count"].Value.ToString());

            if (count == 0)
            {
                return false; //means there is no user with the specfic user anme and ID
            }
            else
            {
                return true;
            }

        }
    }
}
