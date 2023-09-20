using LOGIC.Services.Models.Room;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IRoom_Service
    {
        Task<Generic_ResultSet<Room_ResultSet>> AddRoom(string name, string building, string buildingAddress, int capacity, int type, int computersCount, bool hasProjector, bool isLocked);

        Task<Generic_ResultSet<List<Room_ResultSet>>> GetAllRooms();

        Task<Generic_ResultSet<Room_ResultSet>> GetRoomById(int id);

        Task<Generic_ResultSet<Room_ResultSet>> UpdateRoom(int id, string name, string building, string buildingAddress, int capacity, int type, int computersCount, bool hasProjector, bool isLocked);

        Task<Generic_ResultSet<bool>> DeleteRoom (int id);

        Task<Generic_ResultSet<List<Room_ResultSet>>> GetRoomsByDayAvailable(int day);

        Task<Generic_ResultSet<List<Room_ResultSet>>> GetRoomsByTimeAvailable(int startTime, int endTime);

        Task<Generic_ResultSet<List<Room_ResultSet>>> GetRoomsByCapacity(int minCapacity);
    }
}
