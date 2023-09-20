using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IExtraFunctions
    {
        Task<List<Room>> FilterRoomByDay(int day);

        Task<List<Room>> FilterRoomByTime(int startTime, int endTime);

        Task<List<Room>> FilterRoomByCapacity(int minCapacity);

        Task<List<RoomAvailability>> GetAvailabilitiesFromRoom(int roomId);

        Task<List<Reservation>> GetReservationsFromRoom(int roomId);

        Task<List<Teacher>> GetTeachersFromLecture(int lectureId);
    }
}
