using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class SubRequest
    {
        [Key]
        public int SubRequest_ID { get; set; }

        public DateTime SubRequest_EntryDate { get; set; }

        public int SubRequest_Status { get; set; }

        public DateTime SubRequest_OriginalDate { get; set; }

        public DateTime SubRequest_Date { get; set; }

        public int SubRequest_StartTime { get; set; }

        public int SubRequest_EndTime { get; set; }

        [ForeignKey("Reservation")]
        public int Reservation_ID { get; set; }

        [ForeignKey("Room")]
        public int Room_ID { get; set; }

        public Reservation Reservation { get; set; }

        public Room Room { get; set; }
    }
}
