using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetBar.Model
{
    public class UserModel
    {
        public UserModel()
        {
            ID = 0;
            UserLevel = 0;
            Role = "";
            UserName = "";
            Password = "";
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int UserLevel { get; set; }
    }
}