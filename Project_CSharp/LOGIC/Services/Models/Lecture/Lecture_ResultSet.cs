using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Lecture
{
    public class Lecture_ResultSet
    {
        public int id { get; set; }

        public string type { get; set; }

        public int courseId { get; set; }

        public string courseName { get; set; }

        public int semester { get; set; }

        public string department { get; set; }

        public int totalHours { get; set; }
    }
}
