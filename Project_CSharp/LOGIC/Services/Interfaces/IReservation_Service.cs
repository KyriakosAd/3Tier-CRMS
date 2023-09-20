using LOGIC.Services.Models.Reservation;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IReservation_Service
    {
        Task<Generic_ResultSet<Reservation_ResultSet>> AddReservation(DateTime entryDate, bool isRecurring, DateTime startDate, DateTime endDate, DateTime exactDate, int day, int startTime, int endTime, int roomId);

        Task<Generic_ResultSet<List<Reservation_ResultSet>>> GetAllReservations();

        Task<Generic_ResultSet<List<Reservation_ResultSet>>> GetReservationsByRoom(int roomId);
        
        Task<Generic_ResultSet<Reservation_ResultSet>> GetReservationById(int id);

        Task<Generic_ResultSet<Reservation_ResultSet>> UpdateReservation(int id, DateTime entryDate, bool isRecurring, DateTime startDate, DateTime endDate, DateTime exactDate, int day, int startTime, int endTime, int roomId);

        Task<Generic_ResultSet<bool>> DeleteReservation(int id);
    }
}
