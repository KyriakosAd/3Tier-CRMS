namespace WEB_API.Models.Lecture
{
    public class Lecture_Pass_Object
    {
        public string type { get; set; }

        public int courseId { get; set; }

        public string courseName { get; set; }

        public int semester { get; set; }

        public string department { get; set; }

        public int totalHours { get; set; }
    }
}
