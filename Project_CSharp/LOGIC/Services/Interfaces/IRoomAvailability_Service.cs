using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Models.RoomAvailability;

namespace LOGIC.Services.Interfaces
{
    public interface IRoomAvailability_Service
    {
        Task<Generic_ResultSet<RoomAvailability_ResultSet>> AddRoomAvailability(int day, int startTime, int endTime, int roomId);

        Task<Generic_ResultSet<List<RoomAvailability_ResultSet>>> GetRoomAvailabilitiesByRoom(int roomId);

        Task<Generic_ResultSet<RoomAvailability_ResultSet>> UpdateRoomAvailability(int id, int day, int startTime, int endTime, int roomId);

        Task<Generic_ResultSet<bool>> DeleteRoomAvailability(int id);
    }
}
