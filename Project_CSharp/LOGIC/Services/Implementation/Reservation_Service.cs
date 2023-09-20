using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using LOGIC.Services.Models.Room;
using DAL.Functions.Specific;
using LOGIC.Services.Models.RoomAvailability;

namespace LOGIC.Services.Implementation
{
    public class Reservation_Service : IReservation_Service
    {
        private ICRUD _crud = new CRUD();
        private IExtraFunctions _extraFunctions = new ExtraFunctions();

        public async Task<Generic_ResultSet<Reservation_ResultSet>> AddReservation(DateTime entryDate, bool isRecurring, DateTime startDate, DateTime endDate, DateTime exactDate, int day, int startTime, int endTime, int roomId)
        {
            Generic_ResultSet<Reservation_ResultSet> result = new Generic_ResultSet<Reservation_ResultSet>();
            try
            {
                Reservation Reservation = new Reservation
                {
                    Reservation_EntryDate = entryDate,
                    Reservation_IsRecurring = isRecurring,
                    Reservation_StartDate = startDate,
                    Reservation_EndDate = endDate,
                    Reservation_ExactDate = exactDate,
                    Reservation_Day = day,
                    Reservation_StartTime = startTime,
                    Reservation_EndTime = endTime,
                    Room_ID = roomId
                };

                Reservation = await _crud.Create<Reservation>(Reservation);

                Reservation_ResultSet reservationAdded = new Reservation_ResultSet
                {
                    id = Reservation.Reservation_ID,
                    entryDate = Reservation.Reservation_EntryDate,
                    isRecurring = Reservation.Reservation_IsRecurring,
                    startDate = Reservation.Reservation_StartDate,
                    endDate = Reservation.Reservation_EndDate,
                    exactDate = Reservation.Reservation_ExactDate,
                    day = Reservation.Reservation_Day,
                    startTime = Reservation.Reservation_StartTime,
                    endTime = Reservation.Reservation_EndTime,
                    roomId = Reservation.Room_ID
                };

                result.userMessage = string.Format("The provided reservation was added successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Reservation_Service: AddReservation() method executed successfully.";
                result.result_set = reservationAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the reservation provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reservation_Service: AddReservation(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Reservation_ResultSet>>> GetAllReservations()
        {
            Generic_ResultSet<List<Reservation_ResultSet>> result = new Generic_ResultSet<List<Reservation_ResultSet>>();
            try
            {
                List<Reservation> Reservations = await _crud.ReadAll<Reservation>();

                result.result_set = new List<Reservation_ResultSet>();
                Reservations.ForEach(dres => {
                    result.result_set.Add(new Reservation_ResultSet
                    {
                        id = dres.Reservation_ID,
                        entryDate = dres.Reservation_EntryDate,
                        isRecurring = dres.Reservation_IsRecurring,
                        startDate = dres.Reservation_StartDate,
                        endDate = dres.Reservation_EndDate,
                        exactDate = dres.Reservation_ExactDate,
                        day = dres.Reservation_Day,
                        startTime = dres.Reservation_StartTime,
                        endTime = dres.Reservation_EndTime,
                        roomId = dres.Room_ID
                    });
                });

                result.userMessage = string.Format("All reservations obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Reservation_Service: GetAllReservations() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required reservations from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reservation_Service: GetAllReservations(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Reservation_ResultSet>>> GetReservationsByRoom(int roomId)
        {
            Generic_ResultSet<List<Reservation_ResultSet>> result = new Generic_ResultSet<List<Reservation_ResultSet>>();
            try
            {
                List<Reservation> Reservations = await _extraFunctions.GetReservationsFromRoom(roomId);

                result.result_set = new List<Reservation_ResultSet>();
                Reservations.ForEach(dr => {
                    result.result_set.Add(new Reservation_ResultSet
                    {
                        id = dr.Reservation_ID,
                        entryDate = dr.Reservation_EntryDate,
                        isRecurring = dr.Reservation_IsRecurring,
                        startDate = dr.Reservation_StartDate,
                        endDate = dr.Reservation_EndDate,
                        exactDate = dr.Reservation_ExactDate,
                        day = dr.Reservation_Day,
                        startTime = dr.Reservation_StartTime,
                        endTime = dr.Reservation_EndTime,
                        roomId = dr.Room_ID
                    });
                });

                result.userMessage = string.Format("All reservations for selected room obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Reservation_Service: GetReservationsByRoom() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required reservations from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reservation_Service: GetReservationsByRoom(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Reservation_ResultSet>> GetReservationById(int id)
        {
            Generic_ResultSet<Reservation_ResultSet> result = new Generic_ResultSet<Reservation_ResultSet>();
            try
            {
                Reservation Reservation = await _crud.Read<Reservation>(id);

                if (Reservation == null)
                {
                    throw new Exception();
                }

                Reservation_ResultSet reservationReturned = new Reservation_ResultSet
                {
                    id = Reservation.Reservation_ID,
                    entryDate = Reservation.Reservation_EntryDate,
                    isRecurring = Reservation.Reservation_IsRecurring,
                    startDate = Reservation.Reservation_StartDate,
                    endDate = Reservation.Reservation_EndDate,
                    exactDate = Reservation.Reservation_ExactDate,
                    day = Reservation.Reservation_Day,
                    startTime = Reservation.Reservation_StartTime,
                    endTime = Reservation.Reservation_EndTime,
                    roomId = Reservation.Room_ID
                };

                result.userMessage = string.Format("Reservation with ID {0} was found successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.Reservation_Service: GetReservationById() method executed successfully.";
                result.result_set = reservationReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the reservation provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reservation_Service: GetReservationById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Reservation_ResultSet>> UpdateReservation(int id, DateTime entryDate, bool isRecurring, DateTime startDate, DateTime endDate, DateTime exactDate, int day, int startTime, int endTime, int roomId)
        {
            Generic_ResultSet<Reservation_ResultSet> result = new Generic_ResultSet<Reservation_ResultSet>();
            try
            {
                Reservation Reservation = new Reservation
                {
                    Reservation_ID = id,
                    Reservation_EntryDate = entryDate,
                    Reservation_IsRecurring = isRecurring,
                    Reservation_StartDate = startDate,
                    Reservation_EndDate = endDate,
                    Reservation_ExactDate = exactDate,
                    Reservation_Day = day,
                    Reservation_StartTime = startTime,
                    Reservation_EndTime = endTime,
                    Room_ID = roomId
                };

                Reservation = await _crud.Update<Reservation>(Reservation, id);

                if (Reservation == null)
                {
                    throw new Exception();
                }

                Reservation_ResultSet reservationUpdated = new Reservation_ResultSet
                {
                    id = Reservation.Reservation_ID,
                    entryDate = Reservation.Reservation_EntryDate,
                    isRecurring = Reservation.Reservation_IsRecurring,
                    startDate = Reservation.Reservation_StartDate,
                    endDate = Reservation.Reservation_EndDate,
                    exactDate = Reservation.Reservation_ExactDate,
                    day = Reservation.Reservation_Day,
                    startTime = Reservation.Reservation_StartTime,
                    endTime = Reservation.Reservation_EndTime,
                    roomId = Reservation.Room_ID
                };

                result.userMessage = string.Format("The provided reservation with ID {0} was updated successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.Reservation_Service: UpdateReservation() method executed successfully.";
                result.result_set = reservationUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the reservation provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reservation_Service: UpdateReservation(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteReservation(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                bool reservationDeleted = await _crud.Delete<Reservation>(id);

                if (!reservationDeleted)
                {
                    throw new Exception();
                }

                result.userMessage = string.Format("The reservation with ID {0} was deleted successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.Reservation_Service: DeleteReservation() method executed successfully.";
                result.result_set = reservationDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the reservation provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Reservation_Service: DeleteReservation(): {0}", exception.Message);
            }
            return result;
        }
    }
}
