using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Reservation
{
    public class Reservation_ResultSet
    {
        public int id { get; set; }

        public DateTime entryDate { get; set; }

        public bool isRecurring { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime exactDate { get; set; }

        public int day { get; set; }

        public int startTime { get; set; }

        public int endTime { get; set; }

        public int roomId { get; set; }
    }
}
