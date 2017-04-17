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
using File;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

        [WebMethod]
         public  String  AssignWebServiceAPI(String userName)
        {
          
          
            ///Generate  API 
            Random randgen = new Random();
            String APIKEY = "";
            for (int i = 0; i < 16; i++)
            {

                APIKEY += randgen.Next(1, 9).ToString();
            }
            
            //////Stored Proceda

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertUsernameAndAPI_Key";

            objCommand.Parameters.AddWithValue("@username", userName);
            objCommand.Parameters.AddWithValue("@API_Key", APIKEY);

            int updated = 0;
         updated=   objDB.DoUpdateUsingCmdObj(objCommand);

            if (updated == 0)
            {
                return null;
            }else
            {
                return APIKEY;
            }
        }

        [WebMethod]
        public  Boolean VerifyAPIKey(String APIKey)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //set parameters for stored prosdure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAPI_Key";

            objCommand.Parameters.AddWithValue("@API_Key", APIKey);
         

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

        [WebMethod]
        public  String UploadFile(String API_Key , FileInfoWS OBJFile, String username )
        {
            if (VerifyAPIKey(API_Key))
            {

                //Assign vaules to file object 
                
                //check avaiblae storage

                if (OBJFile != null)
                {

                    BinaryFormatter Serializer = new BinaryFormatter();
                    MemoryStream memStream = new MemoryStream();
                    Byte[] bytefileArray;

                    Serializer.Serialize(memStream, OBJFile);
                    //Create byte array
                    bytefileArray = memStream.ToArray();

                    ////sql code to store the serialized fiel

                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();

                    //set parameters for stored prosdure
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "StoreFile";
                    objCommand.Parameters.AddWithValue("@username", username);
                    objCommand.Parameters.AddWithValue("@file", bytefileArray);
                    objCommand.Parameters.AddWithValue("@uploadDate", OBJFile.UploadDate);
                    objCommand.Parameters.AddWithValue("@fileType", OBJFile.FileType);
                    objCommand.Parameters.AddWithValue("@fileName", OBJFile.FileName);
                    objCommand.Parameters.AddWithValue("@fileSize", OBJFile.FileSize);
                    int updated = 0;
                    updated = objDB.DoUpdateUsingCmdObj(objCommand);
                    if (updated == 0)
                    {
                        return "";
                    }
                    else
                    {
                        String imageurl = "";
                        switch(OBJFile.FileType){
                            case ".jpg" :
                                imageurl= "~/pic/Icon Images/JPG.png";
                                break;

                            case ".mp3":
                                imageurl= "~/pic/Icon Images/MusicIcon.png";
                                break;
                            case ".pdf":
                                imageurl= "~/pic/Icon Images/pdfIcon.png";
                                break;
                            case ".png":
                                imageurl= "~/pic/Icon Images/PNGIcon.png";
                                break;
                            case ".pptx":
                                imageurl= "~/pic/Icon Images/PowerPointIcon.png";
                                break;
                            case ".docx":
                                imageurl = "~/pic/Icon Images/WordIcon.jpg";
                                break;

                        }
                        //get icon extencion
                        return imageurl;


                    }

                }
                else
                {
                    return "File n0t uploaded Succesfully";

                }
                
            }
            else
            {
                return "API Key not found.";
            }

        }
        [WebMethod]
        public  string[] CloudUserStorage()
        {
            string [] stri = new string[10];
            return stri
                ;
        }
    }
}
