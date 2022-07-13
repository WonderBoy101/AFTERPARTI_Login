using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;


namespace Login_Practice_Template
{
    public static class CreateCredentials
    {
        //Main method that gets called from main Program.cs
        public static void EstablishNewUser()
        {
            bool addanotherUser = true;
            
            Program.AllUsers.Add(askfornewCredentials());
            Classes.Afterparti_User.AllUserDetails();
            SaveNewUser(Program.allusersFile);

            Console.WriteLine("Would you like to add another user");
            do
            {
                string answer = Console.ReadLine();
                if (answer == "Yes" || answer == "yes")
                {
                    Console.WriteLine("GLITCH");
                    EstablishNewUser();
                }

                else if (answer == "No" || answer == "no")
                {
                    Console.WriteLine("Enjoy the great wide world of Afterparti :)");
                    addanotherUser = false;
                }
                else
                {
                    Console.WriteLine("Please enter a Yes or a No");
                }
            } while (addanotherUser == true);
        }

        private static Classes.Afterparti_User askfornewCredentials()
        {
            string username = null;
            string password = null;
            string field = null;
            int olduserCounter = Classes.Afterparti_User.Usercounter;

            Console.WriteLine($"Existing Total User Count = {Classes.Afterparti_User.Usercounter.ToString()}");

            Console.WriteLine("Hello prospecting AFTERPARTI user, let's start by entering your desired username");

            username = validateUsername(username);
            password = validatePassword(password);
            field = validateField(field);

            Classes.Afterparti_User NewUser = new Classes.Afterparti_User(username, password, field);

            Console.WriteLine($"New Total User Count = {Classes.Afterparti_User.Usercounter.ToString()}");

            return NewUser;
        }

        //should/(could?) all validate methods be combined into one method.. (maybe using switch cases?)

        private static string validateUsername(string username)
        {
            bool usernameisNull = true;
            do
            {
                username = Console.ReadLine();
                if (!(string.IsNullOrEmpty(username)))
                {
                    usernameisNull = false;
                    Console.WriteLine();
                    Console.WriteLine($"Thank you {username}, now lets set your password. Please input your desired password");
                }
                else
                {
                    Console.WriteLine("Username cannot be empty, please enter a valid username (bitch..)");
                }
            } while (usernameisNull == true);
            return username;
        }

        private static string validatePassword(string password)
        {
            bool passwordisNull = true;
            do
            {
                password = Console.ReadLine();
                if (!(string.IsNullOrEmpty(password)))
                {
                    passwordisNull = false;
                    Console.WriteLine();
                    Console.WriteLine("Your password is all set! Lastly what is your preferred creative field?");
                }
                else
                {
                    //is there a way to make exception callout specifically whether its the username or password that can't be empty??
                    //throw new ArgumentException("Password cannot be empty");
                    Console.WriteLine("Your password cannot be empty, please enter a valid password");
                }
            } while (passwordisNull == true);
            return password;
        }

        private static string validateField(string field)
        {
            bool creativefieldisNull = true;
            do
            {
                field = Console.ReadLine();
                if (!(string.IsNullOrEmpty(field)))
                {
                    creativefieldisNull = false;
                    Console.WriteLine();
                    Console.WriteLine($"Glad to have another member of the community interested in {field}! We'll now direct you to the login screen where you can enter your credentials and find your first studio");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Creative field entry can't be empty, please enter a valid creative field");
                }
            } while (creativefieldisNull == true);
            return field;
        }

        public static string SaveNewUser(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File can not be null or empty");
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Classes.Afterparti_User user in Program.AllUsers)
                    {
                        writer.WriteLine(user.ToString());
                    }
                    writer.Dispose();
                }
            }
            finally
            {
                Console.WriteLine($"{Environment.NewLine}User successfully saved to the Metaverse {Environment.NewLine}");
            }

            return $"{Program.allusersFile}";
        }

        //OLD METHODS
        private static void AdduserOld(string aUsername, string aPassword, string aField)
        {
            //Classes.Afterparti_User.AllUsers = new List<Classes.Afterparti_User>();

            Program.AllUsers.Add(new Classes.Afterparti_User(aUsername, aPassword, aField));
            Console.WriteLine("User successfully added to database");
            Console.WriteLine();
        }
        private static Classes.Afterparti_User askfornewCredentialsOld()
        {
            string username = null;
            string password = null;
            string field = null;
            int olduserCounter = Classes.Afterparti_User.Usercounter;

            Console.WriteLine($"Existing Total User Count = {Classes.Afterparti_User.Usercounter.ToString()}");

            Console.WriteLine("Hello prospecting AFTERPARTI user, let's start by entering your desired username");

            username = validateUsername(username);
            password = validatePassword(password);
            field = validateField(field);

            //Console.WriteLine($"TEST FOR NEW VARIABLE INFO: FYI your username is {username}, your password is {password} and your preffered creative field is {field} :)");

            Classes.Afterparti_User NewUser = new Classes.Afterparti_User(username, password, field);

            //foreach (Classes.Afterparti_User user in Program.AllUsers.ToList())
            //{
            //    if (Classes.Afterparti_User.Usercounter > olduserCounter)
            //    {
            //        NewUser.Username = username;
            //        NewUser.Password = password;
            //        NewUser.Field = field;

            //        //Program.AllUsers.Add(NewUser);

            //        Console.WriteLine("User successfully added to database");
            //        Console.WriteLine();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Couldn't add user");
            //    }
            //}

            Console.WriteLine($"New Total User Count = {Classes.Afterparti_User.Usercounter.ToString()}");

            return NewUser;

            //Adduser(username, password, field);
        }

    }
}