using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.RoomAvailability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class RoomAvailability_Service : IRoomAvailability_Service
    {
        private ICRUD _crud = new CRUD();
        private IExtraFunctions _extraFunctions = new ExtraFunctions();

        public async Task<Generic_ResultSet<RoomAvailability_ResultSet>> AddRoomAvailability(int day, int startTime, int endTime, int roomId)
        {
            Generic_ResultSet<RoomAvailability_ResultSet> result = new Generic_ResultSet<RoomAvailability_ResultSet>();
            try
            {
                RoomAvailability RoomAvailability = new RoomAvailability
                {
                    RoomAvailability_Day = day,
                    RoomAvailability_StartTime = startTime,
                    RoomAvailability_EndTime = endTime,
                    Room_ID = roomId
                };

                RoomAvailability = await _crud.Create<RoomAvailability>(RoomAvailability);

                RoomAvailability_ResultSet roomAdded = new RoomAvailability_ResultSet
                {
                    id = RoomAvailability.RoomAvailability_ID,
                    day = RoomAvailability.RoomAvailability_Day,
                    startTime = RoomAvailability.RoomAvailability_StartTime,
                    endTime = RoomAvailability.RoomAvailability_EndTime,
                    roomId = RoomAvailability.Room_ID
                };

                result.userMessage = string.Format("The provided room availability was added successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.RoomAvailability_Service: AddRoomAvailability() method executed successfully.";
                result.result_set = roomAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the room availability provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.RoomAvailability_Service: AddRoomAvailability(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<RoomAvailability_ResultSet>>> GetRoomAvailabilitiesByRoom(int roomId)
        {
            Generic_ResultSet<List<RoomAvailability_ResultSet>> result = new Generic_ResultSet<List<RoomAvailability_ResultSet>>();
            try
            {
                List<RoomAvailability> RoomAvailabilities = await _extraFunctions.GetAvailabilitiesFromRoom(roomId);

                result.result_set = new List<RoomAvailability_ResultSet>();
                RoomAvailabilities.ForEach(dr => {
                    result.result_set.Add(new RoomAvailability_ResultSet
                    {
                        id = dr.RoomAvailability_ID,
                        day = dr.RoomAvailability_Day,
                        startTime = dr.RoomAvailability_StartTime,
                        endTime = dr.RoomAvailability_EndTime,
                        roomId = dr.Room_ID
                    });
                });

                result.userMessage = string.Format("All room availabilities for selected room obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.RoomAvailability_Service: GetRoomAvailabilitiesByRoom() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required room availabilities from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.RoomAvailability_Service: GetRoomAvailabilitiesByRoom(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<RoomAvailability_ResultSet>> UpdateRoomAvailability(int id, int day, int startTime, int endTime, int roomId)
        {
            Generic_ResultSet<RoomAvailability_ResultSet> result = new Generic_ResultSet<RoomAvailability_ResultSet>();
            try
            {
                RoomAvailability RoomAvailability = new RoomAvailability
                {
                    RoomAvailability_ID = id,
                    RoomAvailability_Day = day,
                    RoomAvailability_StartTime = startTime,
                    RoomAvailability_EndTime = endTime,
                    Room_ID = roomId
                };

                RoomAvailability = await _crud.Update<RoomAvailability>(RoomAvailability, id);

                if (RoomAvailability == null)
                {
                    throw new Exception();
                }

                RoomAvailability_ResultSet roomAvailabilityUpdated = new RoomAvailability_ResultSet
                {
                    id = RoomAvailability.RoomAvailability_ID,
                    day = RoomAvailability.RoomAvailability_Day,
                    startTime = RoomAvailability.RoomAvailability_StartTime,
                    endTime = RoomAvailability.RoomAvailability_EndTime,
                    roomId = RoomAvailability.Room_ID
                };

                result.userMessage = string.Format("The provided room availability was updated successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.RoomAvailability_Service: UpdateRoomAvailability() method executed successfully.";
                result.result_set = roomAvailabilityUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the room availability provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.RoomAvailability_Service: UpdateRoomAvailability(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteRoomAvailability(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                bool roomAvailabilityDeleted = await _crud.Delete<RoomAvailability>(id);

                if (!roomAvailabilityDeleted)
                {
                    throw new Exception();
                }

                result.userMessage = string.Format("The room availability with ID {0} was deleted successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.RoomAvailability_Service: DeleteRoomAvailability() method executed successfully.";
                result.result_set = roomAvailabilityDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the room availability provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.RoomAvailability_Service: DeleteRoomAvailability(): {0}", exception.Message);
            }
            return result;
        }
    }
}