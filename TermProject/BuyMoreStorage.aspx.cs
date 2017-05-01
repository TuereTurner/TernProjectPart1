using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSvc;
using System.Data;
using ExtraStorage;

namespace TermProject
{
    public partial class BuyMoreStorage : System.Web.UI.Page
    {
        string username;
        CloudWebS pxy2 = new CloudWebS();
        WebS.CloudWebS pxy = new WebS.CloudWebS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                username = Session["login"].ToString();
            }
            if (!IsPostBack)
            {
                ddlStoragePlans.DataSource = pxy2.GetStoragePlans();
                ddlStoragePlans.DataTextField = "storagePlanName";
                ddlStoragePlans.DataValueField = "storagePlanAmount";
                ddlStoragePlans.DataBind();
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
                WebS.ExtraStorageUser ESU = new WebS.ExtraStorageUser();

                Double cost = Convert.ToDouble(ddlStoragePlans.SelectedValue);


                String username = Session["login"].ToString();
                String creditCardNumber = txtCreditCardNumber.Text;
                String creditCardExpirationDate = txtExpirationDate.Text;
                String creditCardCVV = txtCVV.Text;
                String billingAddress = txtBillingAddress.Text;
                String phoneNumber = txtPhoneNumber.Text;
                Double storageAmount = Convert.ToDouble(ddlStoragePlans.SelectedValue);
                Double storageCost = cost / 10000;
                String name = txtName.Text;

                       if (username!="" && creditCardNumber!="" && creditCardExpirationDate != "" && creditCardCVV != "" && billingAddress != "" && phoneNumber!= ""   && name != "") { 
                ESU.Username = username;
                ESU.CreditCardNumber = creditCardNumber;
                ESU.CreditCardExpiration = creditCardExpirationDate;
                ESU.CreditCardCVV = creditCardCVV;
                ESU.BillingAddress = billingAddress;
                ESU.PhoneNumber = phoneNumber;
                ESU.StorageAmount = (float)storageAmount;
                ESU.StorageCost = (float)storageCost;
                ESU.Name = name;

                if (pxy.InsertPurchaseExtraStorage(ESU) && pxy.UpdateUserStorageCapacity(ESU))
                {
                    lblOutput.Text = "Storage Plan Purchased";
                }
                else
                {
                    lblOutput.Text = "Something went wrong. Please try again.";
                }
            }
            else
            {
                lblOutput.Text = "All fields Requiered";
            }
        }
    }
}