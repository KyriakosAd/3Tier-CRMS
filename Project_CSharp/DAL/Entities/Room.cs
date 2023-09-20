using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Room
    {
        [Key]
        public int Room_ID { get; set; }

        public string Room_Name { get; set; }

        public string Room_Building { get; set; }

        public string Room_BuildingAddress { get; set; }

        public int Room_Capacity { get; set; }

        public int Room_Type { get; set; }

        public int Room_ComputersCount { get; set; }

        public bool Room_HasProjector { get; set; }

        public bool Room_IsLocked { get; set; }
    }
}
