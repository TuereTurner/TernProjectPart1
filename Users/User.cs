using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class User
    {
        public User() { }

        public User(string username, string password, string typeOfUser, string name,
            string email, string address, string phoneNumber)
        {
            Username = username;
            Password = password;
            TypeOfUser = typeOfUser;
            Name = name;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string TypeOfUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        //Username
        //Password
        //TypeOfUSer  Admin and User  //Dropdown
        //Name
        //Email
        //Address
        //Phone Number

    }
}
