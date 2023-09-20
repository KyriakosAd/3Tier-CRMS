using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TeacherLecture
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Teacher")]
        public int Teacher_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Lecture")]
        public int Lecture_ID { get; set; }

        public Teacher Teacher { get; set; }

        public Lecture Lecture { get; set; }
    }
}
