namespace WEB_API.Models.Reservation
{
    public class Reservation_Pass_Object
    {
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
