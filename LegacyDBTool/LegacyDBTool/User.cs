using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyDBTool
{
    //consider splitting into user and profile
    public class User
    {
        public User()
        {
            images = new List<Image>();
        }

        public string ToString2()
        {
            return "new User{ Id  = \"" + id + "\", " +
            "Username  = \"" + username + "\", " +
            "Password  = \"" + password + "\", " +
            //"RegistrationDate  = \"" + registrationDate + "\", " +
            "RegistrationDate = DateTime.Parse(\"2014-09-01\"), " +
            "Name  = \"" + name + "\", " +
            "Address  = \"" + address + "\", " +
            "Email  = \"" + email + "\", " +
            "PhoneNumber  = \"" + phoneNumber + "\", " +
            "Premium  = \"" + premium + "\", " +
            "Newsletter  = \"" + newsletter + "\", " +
            "Description  = \"" + description + "\", " +
            "Cover  = \"" + cover + "\", " +
            "Avatar  = \"" + avatar + "\", " +
            "BillingName  = \"" + billingName + "\", " +
            "BillingAddress  = \"" + billingAddress + "\", " +
            "BankAccountNum  = \"" + bankAccountNum + "\", " +
            "BankAccountName  = \"" + bankAccountName + "\", " +
            "Balance  = \"" + balance + "\", " +
            "FacebookProfile  = \"" + facebookProfile + "\", " +
            "InstagramProfile  = \"" + instagramProfile + "\", " +
            "Website  = \"" + website + "\"},";
        }
        override public string ToString()
        {
            var generalDataString = 
                "Id: " + id + ", " +
                "Username: " + username + ", " +
                "Password: " + password + ", " +
                "Registration date: " + registrationDate + ", " +
                "Name: " + name + ", " +
                "Address: " + address + ", " +
                "Email: " + email + ", " +
                "PhoneNumber: " + phoneNumber + ", " +
                "Premium: " + premium + ", " +
                "Newsletter: " + newsletter + ", " +
                "Description: " + description + ", " +
                "Cover: " + cover + ", " +
                "Avatar: " + avatar + ", " +
                "Billing name: " + billingName + ", " +
                "Billing address: " + billingAddress + ", " +
                "Bank account number: " + bankAccountNum + ", " +
                "Bank account name: " + bankAccountName + ", " +
                "Balance: " + balance + ", " +
                "Facebook profile: " + facebookProfile + ", " +
                "Instagram profile: " + instagramProfile + ", " +
                "Website: " + website + ", " +
                "Images: \n";

            var uploadedImagesString = string.Empty;

            if (images == null)
            {
                uploadedImagesString = "\tNo images uploaded.\n";
            }
            else if (images.Count == 0)
            {
                //no kepek.aws file exists for this user
                uploadedImagesString = "\tThis user is not capable of uploading images.\n";
            }
            else
            {
                foreach (var image in images)
                {
                    uploadedImagesString += "\t" + image.ToString() + ", ";
                }
            }


            var followingString = "Following:\n";
            if (following == null)
            {
                followingString += "\tThis user follows no other users.\n";
            }
            else
            {
                foreach (var user in following)
                {
                    followingString += "\t" + user + ", ";
                }
            }

            return generalDataString + uploadedImagesString +  followingString;            
        }

        //account info
        public string id;

        public string username;
        //md5, consider changing to sha256
        public string password;
        public DateTime registrationDate;

        //user info
        public string name;
        public string address;
        public string email;
        public string phoneNumber;

        public DateTime premium;
        public bool newsletter;

        public List<string> following;

        //own images
        public List<Image> images;

        //introduction?
        public string description;

        //images
        public string cover;
        public string avatar;

        //billing info
        //consider own struct
        public string billingName;
        public string billingAddress;
        public string bankAccountNum;
        public string bankAccountName;

        //site currency
        public int balance;

        //external availability?
        public string facebookProfile;
        public string instagramProfile;
        public string website;
    }
}
