using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Room
{
    public class Room_ResultSet
    {
        public int id { get; set; }

        public string name { get; set; }

        public string building { get; set; }

        public string buildingAddress { get; set; }

        public int capacity { get; set; }

        public int type { get; set; }

        public int computersCount { get; set; }

        public bool hasProjector { get; set; }

        public bool isLocked { get; set; }
    }
}
