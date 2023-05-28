using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business_App.BL
{
    internal class MUser
    {
        public string username;
        public string password;
        public string role;
        public MUser(string name, string password)
        {
            this.username = name;
            this.password = password;
        }
        public MUser(string name, string password, string role)
        {
            this.username = name;
            this.password = password;
            this.role = role;
        }
        public bool isAdmin()
        {
            if (role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
