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
    [System.Web.Script.Services.ScriptService]
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
        public String AssignWebServiceAPI(String userName)
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
            updated = objDB.DoUpdateUsingCmdObj(objCommand);

            if (updated == 0)
            {
                return null;
            }
            else
            {
                return APIKEY;
            }
        }

        [WebMethod]
        public Boolean VerifyAPIKey(String APIKey)
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
        public String UploadFile(String API_Key, FileInfoWS OBJFile, String username)
        {
            if (VerifyAPIKey(API_Key))
            {

                //Assign vaules to file object 

                //check avaiblae storage

                if (OBJFile != null)
                {
                    if (CheckStorage((OBJFile.FileSize), OBJFile.Username))
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
                        ///upload file
                        updated = objDB.DoUpdateUsingCmdObj(objCommand);
                        UpdateStorageCapacity(OBJFile);
                        if (updated == 0)
                        {
                            return "";
                        }
                        else
                        {
                            String imageurl = "";
                            switch (OBJFile.FileType)
                            {
                                case ".jpg":
                                    imageurl = "~/pic/Icon Images/JPG.png";
                                    break;

                                case ".mp3":
                                    imageurl = "~/pic/Icon Images/MusicIcon.png";
                                    break;
                                case ".pdf":
                                    imageurl = "~/pic/Icon Images/pdfIcon.png";
                                    break;
                                case ".png":
                                    imageurl = "~/pic/Icon Images/PNGIcon.png";
                                    break;
                                case ".pptx":
                                    imageurl = "~/pic/Icon Images/PowerPointIcon.png";
                                    break;
                                case ".docx":
                                    imageurl = "~/pic/Icon Images/WordIcon.jpg";
                                    break;


                            }
                            //subtact from total storage available

                            //set parameters for stored prosdure


                            //get icon extencion
                            return imageurl;


                        }

                    }
                    else
                    {
                        return "Not enough free storage to upload file";
                    }

                }
                else
                {
                    return "File not uploaded Succesfully";

                }
            }
            else
            {
                return "API Key not found.";
            }

        }
        public Boolean UpdateStorageCapacity(FileInfoWS OBJFile)
        {
            DBConnect objDB1 = new DBConnect();
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "updateCapacityUsed";

            objCommand1.Parameters.AddWithValue("@username", OBJFile.Username);
            objCommand1.Parameters.AddWithValue("@fileSize", (OBJFile.FileSize));


            int updated1 = 0;
            updated1 = objDB1.DoUpdateUsingCmdObj(objCommand1);
            return true;
        }
        public Boolean CheckStorage(float fileSize, String userName)
        {
            //sql statemnt that gets usert file storage
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserFileSize";

            objCommand.Parameters.AddWithValue("@username", userName);

            DataSet updated = new DataSet();
            updated = objDB.GetDataSetUsingCmdObj(objCommand);
            //get value of file size

            float TotaluserStorage = Convert.ToSingle(updated.Tables[0].Rows[0]["totalCapacity"].ToString());
            float UsedStorage = Convert.ToSingle(updated.Tables[0].Rows[0]["capacityUsed"].ToString());
            float availableDStarage = TotaluserStorage - UsedStorage;
            if (availableDStarage >= fileSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public string[] CloudUserStorage()
        {
            string[] stri = new string[10];
            return stri
                ;
        }

        [WebMethod]
        public DataSet GetFilesByUser(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserFiles";

            objCommand.Parameters.AddWithValue("@username", userName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            if (set.Tables[0].Rows.Count != 0)
            {
                return set;
            }
            else
            {
                DataSet set1 = new DataSet();
                DataTable tb = new DataTable();
                tb.Clear();
                tb.Columns.Add("File Search Result");
                DataRow row = tb.NewRow();
                row["File Search Result"] = "Error: No files to retrieve";
                tb.Rows.Add(row);
                set1.Tables.Add(tb);
                return set1;
            }


        }
        [WebMethod]
        public String DeleteFile(String username, String fileName, float size)
        {
            DBConnect objDB1 = new DBConnect();
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "DeleteFile";

            objCommand1.Parameters.AddWithValue("@username", username);
            objCommand1.Parameters.AddWithValue("@fileName", (fileName));


            int updated = 0;
            updated = objDB1.DoUpdateUsingCmdObj(objCommand1);
            //add storage back
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "updateCapacityUsed";

            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@fileSize", -(size));


            int updated1 = 0;
            updated1 = objDB1.DoUpdateUsingCmdObj(objCommand1);
            if (updated1 == 0)
            {
                return "File Not Deleted";
            }
            else
            {
                InsertUserTransactions(username, username + " Deleted File " + fileName + "", DateTime.Today.ToString());

                return "File Successfully Deleted";
            }
        }
        [WebMethod]
        public String UpDateFile(FileInfoWS OBJFile)
        {

            BinaryFormatter Serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] bytefileArray;

            Serializer.Serialize(memStream, OBJFile);
            //Create byte array
            bytefileArray = memStream.ToArray();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //set parameters for stored prosdure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateFile";
            objCommand.Parameters.AddWithValue("@username", OBJFile.Username);
            objCommand.Parameters.AddWithValue("@file", bytefileArray);
            objCommand.Parameters.AddWithValue("@uploadDate", OBJFile.UploadDate);
            objCommand.Parameters.AddWithValue("@fileType", OBJFile.FileType);
            objCommand.Parameters.AddWithValue("@fileName", OBJFile.FileName);
            objCommand.Parameters.AddWithValue("@fileSize", OBJFile.FileSize);
            int updated = 0;
            ///upload file
            updated = objDB.DoUpdateUsingCmdObj(objCommand);
            UpdateStorageCapacity(OBJFile);
            if (updated == 0)
            {
                return "File not Updated";
            }
            else
            {
                //record trannsaction
                InsertUserTransactions(OBJFile.Username, OBJFile.Username + " Updated File " + OBJFile.FileName + "", DateTime.Today.ToString());
                return "File Successfully updated.";
            }
        }

        public GridView EditUserByAdmin(GridView gv, int i)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "EditUserByAdmin";

            string username = ((TextBox)gv.Rows[i].Cells[0].Controls[0]).Text;
            string password = ((TextBox)gv.Rows[i].Cells[1].Controls[0]).Text;
            string typeOfUser = ((TextBox)gv.Rows[i].Cells[2].Controls[0]).Text;
            string name = ((TextBox)gv.Rows[i].Cells[3].Controls[0]).Text;
            string email = ((TextBox)gv.Rows[i].Cells[4].Controls[0]).Text;
            string address = ((TextBox)gv.Rows[i].Cells[5].Controls[0]).Text;
            string phoneNumber = ((TextBox)gv.Rows[i].Cells[6].Controls[0]).Text;
            string totalCapacity = ((TextBox)gv.Rows[i].Cells[7].Controls[0]).Text;

            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@password", password);
            objCommand.Parameters.AddWithValue("@typeOfUser", typeOfUser);
            objCommand.Parameters.AddWithValue("@name", name);
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@address", address);
            objCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            objCommand.Parameters.AddWithValue("@totalCapacity", totalCapacity);

            objDB.DoUpdateUsingCmdObj(objCommand);

            gv.DataSource = GetAllUsers();

            return gv;
        }

        [WebMethod]
        public DataSet GetAllUsers()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllUsers";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        [WebMethod]
        public void DeleteUser(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteUSer";

            objCommand.Parameters.AddWithValue("@username", username);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        [WebMethod]
        public DataSet SelectFilesWithIcons(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserFiles";

            objCommand.Parameters.AddWithValue("@username", userName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);

            //add a roe to the table
            DataTable tb = new DataTable();
            tb.Clear();
            tb.Columns.Add("File Icon");



            String fileextse = "";

            //get file extresion
            for (int i = 0; i < set.Tables[0].Rows.Count; ++i)
            {


                fileextse = set.Tables[0].Rows[i]["fileType"].ToString();
                DataRow row = tb.NewRow();



                switch (fileextse)
                {
                    case ".jpg":
                        row["File Icon"] = "~/pic/Icon Images/JPG.png";
                        tb.Rows.Add(row);
                        break;

                    case ".mp3":
                        row["File Icon"] = "~/pic/Icon Images/MusicIcon.png";
                        tb.Rows.Add(row);
                        break;
                    case ".pdf":
                        row["File Icon"] = "~/pic/Icon Images/pdfIcon.png";
                        tb.Rows.Add(row);
                        break;
                    case ".png":
                        row["File Icon"] = "~/pic/Icon Images/PNGIcon.png";
                        tb.Rows.Add(row);
                        break;
                    case ".pptx":
                        row["File Icon"] = "~/pic/Icon Images/PowerPointIcon.png";
                        tb.Rows.Add(row);
                        break;
                    case ".docx":
                        row["File Icon"] = "~/pic/Icon Images/WordIcon.jpg";
                        tb.Rows.Add(row);
                        break;
                }

            }
            set.Tables.Add(tb);
            return set;
        }
        public GridView UserEditUser(GridView gv, int i)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UserEditUser";

            string username = ((TextBox)gv.Rows[i].Cells[0].Controls[0]).Text;
            string password = ((TextBox)gv.Rows[i].Cells[1].Controls[0]).Text;
            //string typeOfUser = ((TextBox)gv.Rows[i].Cells[2].Controls[0]).Text;
            string name = ((TextBox)gv.Rows[i].Cells[3].Controls[0]).Text;
            string email = ((TextBox)gv.Rows[i].Cells[4].Controls[0]).Text;
            string address = ((TextBox)gv.Rows[i].Cells[5].Controls[0]).Text;
            string phoneNumber = ((TextBox)gv.Rows[i].Cells[6].Controls[0]).Text;
            //string totalCapacity = ((TextBox)gv.Rows[i].Cells[7].Controls[0]).Text;

            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@password", password);
            //objCommand.Parameters.AddWithValue("@typeOfUser", typeOfUser);
            objCommand.Parameters.AddWithValue("@name", name);
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@address", address);
            objCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            //objCommand.Parameters.AddWithValue("@totalCapacity", totalCapacity);

            objDB.DoUpdateUsingCmdObj(objCommand);

            gv.DataSource = GetAllUsers();

            return gv;
        }
        [WebMethod]
        public String InsertUserTransactions(String Username, String Desc, String date)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //set parameters for stored prosdure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertRecentUserTransaction";
            objCommand.Parameters.AddWithValue("@desc", Desc);
            objCommand.Parameters.AddWithValue("@date", date);
            objCommand.Parameters.AddWithValue("@userName", Username);

            int updated = 0;
            ///upload file
            updated = objDB.DoUpdateUsingCmdObj(objCommand);

            if (updated == 0)
            {
                return "Transaction not recorded";
            }
            else
            {
                return "Transaction Successfully Recorded.";
            }
        }
        [WebMethod]
        public DataSet SelectUserTransactions(String Username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectUserTransactions";

            objCommand.Parameters.AddWithValue("@username", Username);
            objCommand.Parameters.AddWithValue("@dateOne", DateTime.Today.ToString());
            objCommand.Parameters.AddWithValue("@dateTwo", DateTime.Today.AddDays(-1).ToString());

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);

            return set;
        }
        [WebMethod]
        public DataSet GetFilesByIcon(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserFiles";

            objCommand.Parameters.AddWithValue("@username", userName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            ///add colum to dataset

            //////////
            DataSet set1 = new DataSet();








            /////////

            DataTable tb = new DataTable();
            tb.Clear();
            tb.Columns.Add("FileIcon");
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                String ext = set.Tables[0].Rows[i]["fileType"].ToString();

                DataRow row = tb.NewRow();


                switch (ext)
                {
                    case ".jpg":
                        row["FileIcon"] = "~/pic/Icon Images/JPG.png";
                        tb.Rows.Add(row);

                        break;

                    case ".mp3":
                        row["FileIcon"] = "~/pic/Icon Images/MusicIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".pdf":
                        row["FileIcon"] = "~/pic/Icon Images/pdfIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".png":
                        row["FileIcon"] = "~/pic/Icon Images/PNGIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".pptx":
                        row["FileIcon"] = "~/pic/Icon Images/PowerPointIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".docx":
                        row["FileIcon"] = "~/pic/Icon Images/WordIcon.jpg";
                        tb.Rows.Add(row);

                        break;
                }
            }
            set1.Tables.Add(tb);
            return set1;
        }
    }
}
