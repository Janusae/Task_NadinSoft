using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.EntityTable
{
    public class Users : BaseClass
    {
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
    public enum UserRole
    {
        admin,
        User
    }

}



