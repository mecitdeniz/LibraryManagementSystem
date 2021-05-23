using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem
{
    public class User
    {
        private int id;
        private string fullName;
        private string userName;
        private string password;

        public User(int id, string fullName, string userName, string password)
        {
            this.id = id;
            this.fullName = fullName;
            this.userName = userName;
            this.password = password;
        }

        public int ID { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName= value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }

}