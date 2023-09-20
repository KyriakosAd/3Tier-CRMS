using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Reservation
    {
        [Key]
        public int Reservation_ID { get; set; }

        public DateTime Reservation_EntryDate { get; set; }

        public bool Reservation_IsRecurring { get; set; }

        public DateTime Reservation_StartDate { get; set; }

        public DateTime Reservation_EndDate { get; set; }

        public DateTime Reservation_ExactDate { get; set; }

        public int Reservation_Day { get; set; }

        public int Reservation_StartTime { get; set; }

        public int Reservation_EndTime { get; set; }

        [ForeignKey("Room")]
        public int Room_ID { get; set; }

        public Room Room { get; set; }
    }
}
