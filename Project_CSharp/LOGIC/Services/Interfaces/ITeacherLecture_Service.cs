using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models.TeacherLecture;
using LOGIC.Services.Models.Teacher;

namespace LOGIC.Services.Interfaces
{
    public interface ITeacherLecture_Service
    {
        Task<Generic_ResultSet<TeacherLecture_ResultSet>> AddTeacherLecture(int teacherId, int lectureId);

        Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetTeachersOfLecture(int lectureId);
    }
}
