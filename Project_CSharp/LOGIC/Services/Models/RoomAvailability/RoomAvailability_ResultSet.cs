using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.RoomAvailability
{
    public class RoomAvailability_ResultSet
    {
        public int id { get; set; }

        public int day { get; set; }

        public int startTime { get; set; }

        public int endTime { get; set; }

        public int roomId { get; set; }
    }
}
