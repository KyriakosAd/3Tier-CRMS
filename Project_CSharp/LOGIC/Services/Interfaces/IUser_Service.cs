using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IUser_Service
    {
        Task<Generic_ResultSet<User_ResultSet>> AddUser(string name, string password, string email, string department, string role);

        Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers();

        Task<Generic_ResultSet<User_ResultSet>> GetUserById(int id);

        Task<Generic_ResultSet<User_ResultSet>> UpdateUser(int id, string name, string password, string email, string department, string role);

        Task<Generic_ResultSet<bool>> DeleteUser(int id);
    }
}
