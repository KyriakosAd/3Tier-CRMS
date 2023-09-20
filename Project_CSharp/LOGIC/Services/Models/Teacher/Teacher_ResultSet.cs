using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Teacher
{
    public class Teacher_ResultSet
    {
        public int id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public int userId { get; set; }
    }
}
