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
using ExtraStorage;

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
                    if (CheckStorage((OBJFile.FileSize), username))
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
                        objCommand.Parameters.AddWithValue("@uploadDate", DateTime.Today.ToShortDateString());
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
                //deserialize the file



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
        //seltes file addes it to trash bin //tracks the transaction
        [WebMethod]
        public String DeleteFile(String username, FileInfoWS file)
        {
            String fileName = file.FileName;
            float size = file.FileSize;
            byte[] bytefileArray = file.File;

            DBConnect objDB1 = new DBConnect();
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "DeleteFile";

            objCommand1.Parameters.AddWithValue("@username", username);
            objCommand1.Parameters.AddWithValue("@fileName", (fileName));


            int updated = 0;
            updated = objDB1.DoUpdateUsingCmdObj(objCommand1);



            if (updated == 0)
            {
                return "File Not Deleted";
            }
            else
            {
                //add storage back
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "updateCapacityUsed";

                objCommand.Parameters.AddWithValue("@username", username);
                objCommand.Parameters.AddWithValue("@fileSize", -(size));

                //
                objDB.DoUpdateUsingCmdObj(objCommand);
                //add deletede file to dleted file table 
                DBConnect objDB2 = new DBConnect();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "InsertDeletedFile";
                objCommand2.Parameters.AddWithValue("@file", bytefileArray);
                objCommand2.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString().ToString());
                objCommand2.Parameters.AddWithValue("@fileType", file.FileType);
                objCommand2.Parameters.AddWithValue("@fileName", fileName);
                objCommand2.Parameters.AddWithValue("@fileSize", size);

                objCommand2.Parameters.AddWithValue("@username", username);
                objDB2.DoUpdateUsingCmdObj(objCommand2);

                ////track user movements 
                InsertUserTransactions(username, username + " Deleted File " + fileName + "", DateTime.Today.ToString());

                return "File Successfully Deleted";
            }
        }
        [WebMethod]
        public String UpDateFile(FileInfoWS OBJFile, String newFileName)
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
                //add file to recovey old version file
                SqlCommand objCommand1 = new SqlCommand();

                //set parameters for stored prosdure
                objCommand1.CommandType = CommandType.StoredProcedure;
                objCommand1.CommandText = "InsertRecoveryFile";
                objCommand1.Parameters.AddWithValue("@username", OBJFile.Username);
                objCommand1.Parameters.AddWithValue("@file", bytefileArray);
                objCommand1.Parameters.AddWithValue("@Date", OBJFile.UploadDate);
                objCommand1.Parameters.AddWithValue("@fileType", OBJFile.FileType);
                objCommand1.Parameters.AddWithValue("@fileName", OBJFile.FileName);
                objCommand1.Parameters.AddWithValue("@fileSize", OBJFile.FileSize);

                objCommand1.Parameters.AddWithValue("@versionNUM", newFileName);

                ///insert
                updated = objDB.DoUpdateUsingCmdObj(objCommand1);


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
        public GridView UserEditUser(GridView gv, int i, String thisUser)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UserEditUser";

            string username = thisUser;
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
            DataColumn col = new DataColumn();

            col.ColumnName = "FileIcon";
            /////////


            DataTable tb = new DataTable();
            tb.TableName = "Icons";
            DataRow row;
            tb.Columns.Add(col);


            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                String ext = set.Tables[0].Rows[i]["fileType"].ToString();




                switch (ext)
                {
                    case ".jpg":
                        row = tb.NewRow();

                        row[0] = "~/pic/Icon Images/JPG.png";
                        tb.Rows.Add(row);

                        break;

                    case ".mp3":
                        row = tb.NewRow();
                        row[0] = "~/pic/Icon Images/MusicIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".pdf":
                        row = tb.NewRow();
                        row[0] = "~/pic/Icon Images/pdfIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".png":
                        row = tb.NewRow();
                        row[0] = "~/pic/Icon Images/PNGIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".pptx":
                        row = tb.NewRow();
                        row[0] = "~/pic/Icon Images/PowerPointIcon.png";
                        tb.Rows.Add(row);

                        break;
                    case ".docx":
                        row = tb.NewRow();
                        row[0] = "~/pic/Icon Images/WordIcon.jpg";
                        tb.Rows.Add(row);

                        break;
                }
            }
            set1.Tables.Add(tb);
            return set1;
        }

        [WebMethod]
        public String GetAccountType(String username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet ds = new DataSet();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAccountType";

            objCommand.Parameters.AddWithValue("@username", username);

            ds = objDB.GetDataSetUsingCmdObj(objCommand);

            //string dsToString = ds.Tables[0].Rows[i]["username"].ToString()

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["typeOfUser"].ToString() == "Cloud User")
                {
                    return "Cloud User";
                }
                else
                {
                    return "Cloud Administrator";
                }
            }
            return null;
        }

        [WebMethod]
        public Boolean CheckDuplicateUsername(string username)
        {
            Boolean retVal = false;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUsernames";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            //ds.Tables[0].Rows[i]["username"].ToString();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["username"].ToString() == username)
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
            }
            return retVal;
        }

        [WebMethod]
        public DataSet SelectAllDeletedFiles(String Username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectDeletedFiles";

            objCommand.Parameters.AddWithValue("@username", Username);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);

            return set;
        }
        [WebMethod]
        public DataSet SelectAlRevery_OlderVersionFiles(String Username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectFile_OlderVersion_Recovery";

            objCommand.Parameters.AddWithValue("@username", Username);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);

            return set;
        }

        [WebMethod]
        public DataSet GetStoragePlans()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet ds;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetStoragePlans";

            return ds = objDB.GetDataSetUsingCmdObj(objCommand);
        }

        [WebMethod]
        public Boolean InsertPurchaseExtraStorage(ExtraStorageUser ESU)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertExtraStorage";

            if (ESU != null)
            {

                objCommand.Parameters.AddWithValue("@username", ESU.Username);
                objCommand.Parameters.AddWithValue("@creditCardNumber", ESU.CreditCardNumber);
                objCommand.Parameters.AddWithValue("@creditCardExpiration", ESU.CreditCardExpiration);
                objCommand.Parameters.AddWithValue("@creditCardCVV", ESU.CreditCardCVV);
                objCommand.Parameters.AddWithValue("@billingAddress", ESU.BillingAddress);
                objCommand.Parameters.AddWithValue("@phoneNumber", ESU.PhoneNumber);
                objCommand.Parameters.AddWithValue("@storageAmount", ESU.StorageAmount);
                objCommand.Parameters.AddWithValue("@storageCost", ESU.StorageCost);
                objCommand.Parameters.AddWithValue("@name", ESU.Name);

                objDB.DoUpdateUsingCmdObj(objCommand);

                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public Boolean UpdateUserStorageCapacity(ExtraStorageUser ESU)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateStorageAmount";

            objCommand.Parameters.AddWithValue("@username", ESU.Username);
            objCommand.Parameters.AddWithValue("@storageAmount", ESU.StorageAmount);

            int count = objDB.DoUpdateUsingCmdObj(objCommand);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public Boolean AskQuestion(String username, String question)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertQuestions";

            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@question", question);

            int count = objDB.DoUpdateUsingCmdObj(objCommand);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public Boolean AnswerQuestion(String answerUsername, String answer, int questionsID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AnswerQuestion";

            objCommand.Parameters.AddWithValue("@answerUsername", answerUsername);
            objCommand.Parameters.AddWithValue("@answer", answer);
            objCommand.Parameters.AddWithValue("@questionsID", questionsID);

            int count = objDB.DoUpdateUsingCmdObj(objCommand);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public DataSet GetQuestions()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetQuestions";

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            return ds;
        }

        [WebMethod]
        public DataSet GetSpecificUser(String username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSpecificUser";

            objCommand.Parameters.AddWithValue("@username", username);

            DataSet ds;

            return ds = objDB.GetDataSetUsingCmdObj(objCommand);
        }
        [WebMethod]
        public DataSet SelectOneFFile(String userName, String fileName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectOneFile";

            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@filename", fileName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            return set;
        }
        [WebMethod]
        public DataSet SelectOldFileVserion(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectFile_OlderVersion_Recovery";

            objCommand.Parameters.AddWithValue("@userName", userName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            return set;
        }
        [WebMethod]
        public DataSet SelectDDeletedFiles(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectDeletedFiles";

            objCommand.Parameters.AddWithValue("@userName", userName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            return set;
        }
        [WebMethod]
        public DataSet SelectOneRecoveredFFile(String userName, String fileName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectOneFileFromRecoveryFiles";

            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@filename", fileName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            return set;
        }
        [WebMethod]
        public DataSet SelectOneDELETEDFFile(String userName, String fileName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectOneFileFromDeletedFiles";

            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@filename", fileName);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            return set;
        }

        [WebMethod]
        public int DeleteFromDELETEDFFile(String userName, String fileName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteFileFromDeletedFIles";

            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@filename", fileName);
            int i = 0;
            i = objDB.DoUpdateUsingCmdObj(objCommand);
            return i;
        }
        [WebMethod]
        public int DeleteFromRecoveredFFile(String userName, String fileName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteFileFromRecoveredFIles";

            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@filename", fileName);

            int i = 0;
            i = objDB.DoUpdateUsingCmdObj(objCommand);
            return i;
        }

        [WebMethod]
        public DataSet GetCloudUsers()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet ds;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectCloudUsers";

            return ds = objDB.GetDataSetUsingCmdObj(objCommand);
        }
    




           [WebMethod]

        public int InsertuSERObject(String username)
        {
            //generic obkect
            UserObject useObj = new UserObject();

            ///add colum to dataset
            ///
            DataTable tb = new DataTable();
            tb.Columns.Add(new DataColumn("fileName"));
            tb.Columns.Add(new DataColumn("fileType"));
            tb.Columns.Add(new DataColumn("fileSize"));
            tb.Columns.Add(new DataColumn("uploadDate"));
            DataSet set1 = new DataSet();


            DataRow row;
             row=   tb.NewRow();
            row[0] = " No files Uploaded";
            tb.Rows.Add(row);
            set1.Tables.Add(tb);

            useObj.UserFilesObj = set1;
            useObj.Username = username;
            

            BinaryFormatter Serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] bytefileArray;

            Serializer.Serialize(memStream, useObj);
            //Create byte array
            bytefileArray = memStream.ToArray();

            ////sql code to store the serialized fiel


            DBConnect objDB1 = new DBConnect();
            SqlCommand objCommand1 = new SqlCommand();


            //set parameters for stored prosdure
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "InsertUSERObject";
            objCommand1.Parameters.AddWithValue("@username", username);
            objCommand1.Parameters.AddWithValue("@fileOnjects", bytefileArray);

            int ans = 0;
            ///upload file
            ans = objDB1.DoUpdateUsingCmdObj(objCommand1);
            return ans;
        }
        [WebMethod]
        public int DeleteAllFiles(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteAllFIles";

            objCommand.Parameters.AddWithValue("@userName", userName);


            int i = 0;
            i = objDB.DoUpdateUsingCmdObj(objCommand);
            return i;
        }
        [WebMethod]
        public DataSet sELECTuSERObject(String userName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectUserObject";

            objCommand.Parameters.AddWithValue("@userName", userName);


            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])set.Tables[0].Rows[0]["CloudObject"];

            BinaryFormatter deSerializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream(byteArray);

            UserObject objFile = (UserObject)deSerializer.Deserialize(memStream);
            DataSet set1 = new DataSet();
            set1 = objFile.UserFilesObj;
            return set1;
        }



        [WebMethod]
        public int UpDateuSERObject(String username)
        {
            UserObject useObj = new UserObject();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserFilesNotFileData";

            objCommand.Parameters.AddWithValue("@username", username);

            DataSet set = new DataSet();
            set = objDB.GetDataSetUsingCmdObj(objCommand);
            ///add colum to dataset


            //  byte[] files = new byte[set.Tables[0].Rows.Count];
            //  for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            //  {

            //   files[i] = (byte)set.Tables[0].Rows[i]["file"];
            //  }


            /// useObj.FileObject = files;
            useObj.Username = username;
            useObj.UserFilesObj = set;

            BinaryFormatter Serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] bytefileArray;

            Serializer.Serialize(memStream, useObj);
            //Create byte array
            bytefileArray = memStream.ToArray();

            ////sql code to store the serialized fiel


            DBConnect objDB1 = new DBConnect();
            SqlCommand objCommand1 = new SqlCommand();


            //set parameters for stored prosdure
            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "UpdateUserCloudOBJ";
            objCommand1.Parameters.AddWithValue("@username", username);
            objCommand1.Parameters.AddWithValue("@fileOBJ", bytefileArray);

            int set1 = 0;
            ///upload file
            set1 = objDB1.DoUpdateUsingCmdObj(objCommand1);
            return set1;
        }
        [WebMethod]
        public int stuff()
        {
            return 2;
        }

    }
}
