using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.User
{
    public class User_ResultSet
    {
        public int id { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string department { get; set; }

        public string role { get; set; }
    }
}
