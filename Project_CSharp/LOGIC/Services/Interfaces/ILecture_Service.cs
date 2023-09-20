using LOGIC.Services.Models.Lecture;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ILecture_Service
    {
        Task<Generic_ResultSet<Lecture_ResultSet>> AddLecture(string type, int courseId, string courseName, int semester, string department, int totalHours);

        Task<Generic_ResultSet<List<Lecture_ResultSet>>> GetAllLectures();

        Task<Generic_ResultSet<Lecture_ResultSet>> GetLectureById(int id);

        Task<Generic_ResultSet<Lecture_ResultSet>> UpdateLecture(int id, string type, int courseId, string courseName, int semester, string department, int totalHours);

        Task<Generic_ResultSet<bool>> DeleteLecture(int id);
    }
}
