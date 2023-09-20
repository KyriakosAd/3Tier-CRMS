using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class RoomAvailability
    {
        [Key]
        public int RoomAvailability_ID { get; set; }

        public int RoomAvailability_Day { get; set; }

        public int RoomAvailability_StartTime { get; set; }

        public int RoomAvailability_EndTime { get; set; }

        [ForeignKey("Room")]
        public int Room_ID { get; set; }

        public Room Room { get; set; }
    }
}
