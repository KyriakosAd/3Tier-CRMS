using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Lecture
    {
        [Key]
        public int Lecture_ID { get; set; }

        public string Lecture_Type { get; set; }

        public int Lecture_CourseID { get; set; }

        public string Lecture_CourseName { get; set; }

        public int Lecture_Semester { get; set; }

        public string Lecture_Department { get; set; }

        public int Lecture_TotalHours { get; set; }
    }
}
