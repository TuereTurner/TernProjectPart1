using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraStorage
{
    public class ExtraStorageUser
    {
        public ExtraStorageUser()
        {

        }

        public ExtraStorageUser (String username, String creditCardNumber, String creditCardExpiration, String creditCardCVV, String billingAddress, String phoneNumber, float storageAmount,
            float storageCost, String name)
        {
            Username = username;
            CreditCardNumber = creditCardNumber;
            CreditCardExpiration = creditCardExpiration;
            CreditCardCVV = creditCardCVV;
            BillingAddress = billingAddress;
            PhoneNumber = phoneNumber;
            StorageAmount = storageAmount;
            StorageCost = storageCost;
            Name = name;
        }

        public String Username { get; set; }
        public String CreditCardNumber { get; set; }
        public String CreditCardExpiration { get; set; }
        public String CreditCardCVV { get; set; }
        public String BillingAddress { get; set; }
        public String PhoneNumber { get; set; }
        public float StorageAmount { get; set; }
        public float StorageCost { get; set; }
        public String Name { get; set; }
    }
}
