using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        public string User_Name { get; set; }

        public string User_Password { get; set; }

        public string User_Email { get; set; }

        public string User_Department { get; set; }

        public string User_Role { get; set; }
    }
}
