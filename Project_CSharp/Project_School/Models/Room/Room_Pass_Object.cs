namespace WEB_API.Models.Room
{
    public class Room_Pass_Object
    {
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
