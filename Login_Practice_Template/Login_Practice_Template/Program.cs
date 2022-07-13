using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;
using System.Linq;

namespace Login_Practice_Template
{
    class Program
    {
        //public static List<Classes.Afterparti_User> AllUsers { get; set; }
        public static List<Classes.Afterparti_User> AllUsers = new List<Classes.Afterparti_User>();
        public const string allusersFile = @"/Users/David1/Downloads/Projects/Coding/AFTERPARTI/AFTERPARTI_Login/Login_Practice_Template/Login_Practice_Template/AllUsers_List";

        static void Main(string[] args)
        {
            //AllUsers = File.ReadAllLines(allusersFile).ToList();
            Classes.Afterparti_User.AddUserTest();
            CreateCredentials.EstablishNewUser();
            //Classes.Afterparti_User.AllUserDetails();

        }

        
    }
}
