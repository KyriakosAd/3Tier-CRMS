using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Teacher
    {
        [Key]
        public int Teacher_ID { get; set; }

        public string Teacher_Name { get; set; }

        public string Teacher_Type { get; set; }

        [ForeignKey("User")]
        public int User_ID { get; set; }

        public User User { get; set; }
    }
}
