using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Login_Practice_Template.Classes
{

    public class Afterparti_User
    {
        //public static List<Afterparti_User> AllUsers { get; set; }
        

        //CLASS ATTRIBUTES
        public string Username { get; set; }
        public string Password { get; set; }
        public string Field { get; set; }
        public static int Usercounter = 0;

        public Afterparti_User(string aUsername, string aPassword, string aField)
        {
            Username = aUsername;
            Password = aPassword;
            Field = aField;
            Usercounter++;
        }

        public static void AddUserTest()
        {
            Program.AllUsers.Add(new Afterparti_User("Wonderboy21", "Milkshake101", "Architecture"));
            Program.AllUsers.Add(new Afterparti_User("Zhangman1", "weed420", "rapping"));
            Console.WriteLine("User successfully added");
            CreateCredentials.SaveNewUser(Program.allusersFile);

            AllUserDetails();
        }

        public static void AllUserDetails()
        {
            Console.WriteLine("----------ALL USERS LISTED----------");

            foreach (Afterparti_User user in Program.AllUsers)
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Finished listing out all users");
        }

        //public string UserDetails(int userCounter)
        //{
        //    return string.Format($"{Username} is a users who's password is {Password} ;) who's interested/practices {Field}");
        //}

        public override string ToString()
        {
            return $"USERNAME: {this.Username}, PASSWORD: {this.Password}, CREATIVE FIELD: {this.Field}";
        }

    }

}
