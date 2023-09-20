using LOGIC.Services.Models.Teacher;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ITeacher_Service
    {
        Task<Generic_ResultSet<Teacher_ResultSet>> AddTeacher(string name, string type, int userId);

        Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetAllTeachers();

        Task<Generic_ResultSet<Teacher_ResultSet>> GetTeacherById(int id);

        Task<Generic_ResultSet<Teacher_ResultSet>> UpdateTeacher(int id, string name, string type, int userId);

        Task<Generic_ResultSet<bool>> DeleteTeacher(int id);
    }
}
