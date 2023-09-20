using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Room;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using DAL.Functions.Specific;

namespace LOGIC.Services.Implementation
{
    public class Room_Service : IRoom_Service
    {
        private ICRUD _crud = new CRUD();
        private IExtraFunctions _extraFunctions = new ExtraFunctions();

        public async Task<Generic_ResultSet<Room_ResultSet>> AddRoom(string name, string building, string buildingAddress, int capacity, int type, int computersCount, bool hasProjector, bool isLocked)
        {
            Generic_ResultSet<Room_ResultSet> result = new Generic_ResultSet<Room_ResultSet>();
            try
            {
                Room Room = new Room
                {
                    Room_Name = name,
                    Room_Building = building,
                    Room_BuildingAddress = buildingAddress,
                    Room_Capacity = capacity,
                    Room_Type = type,
                    Room_ComputersCount = computersCount,
                    Room_HasProjector = hasProjector,
                    Room_IsLocked = isLocked
                };

                Room = await _crud.Create<Room>(Room);

                Room_ResultSet roomAdded = new Room_ResultSet
                {
                    id = Room.Room_ID,
                    name = Room.Room_Name,
                    building = Room.Room_Building,
                    buildingAddress = Room.Room_BuildingAddress,
                    capacity = Room.Room_Capacity,
                    type = Room.Room_Type,
                    computersCount = Room.Room_ComputersCount,
                    hasProjector = Room.Room_HasProjector,
                    isLocked = Room.Room_IsLocked
                };

                result.userMessage = string.Format("The provided room {0} was added successfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: AddRoom() method executed successfully.";
                result.result_set = roomAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the room provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: AddRoom(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Room_ResultSet>>> GetAllRooms()
        {
            Generic_ResultSet<List<Room_ResultSet>> result = new Generic_ResultSet<List<Room_ResultSet>>();
            try
            {
                List<Room> Rooms = await _crud.ReadAll<Room>();

                result.result_set = new List<Room_ResultSet>();
                Rooms.ForEach(dr => {
                    result.result_set.Add(new Room_ResultSet
                    {
                        id = dr.Room_ID,
                        name = dr.Room_Name,
                        building = dr.Room_Building,
                        buildingAddress = dr.Room_BuildingAddress,
                        capacity = dr.Room_Capacity,
                        type = dr.Room_Type,
                        computersCount = dr.Room_ComputersCount,
                        hasProjector = dr.Room_HasProjector,
                        isLocked = dr.Room_IsLocked
                    });
                });

                result.userMessage = string.Format("All rooms obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: GetAllRooms() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required rooms from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: GetAllRooms(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Room_ResultSet>> GetRoomById(int id)
        {
            Generic_ResultSet<Room_ResultSet> result = new Generic_ResultSet<Room_ResultSet>();
            try
            {
                Room Room = await _crud.Read<Room>(id);

                if (Room == null)
                {
                    throw new Exception();
                }

                Room_ResultSet roomReturned = new Room_ResultSet
                {
                    id = Room.Room_ID,
                    name = Room.Room_Name,
                    building = Room.Room_Building,
                    buildingAddress = Room.Room_BuildingAddress,
                    capacity = Room.Room_Capacity,
                    type = Room.Room_Type,
                    computersCount = Room.Room_ComputersCount,
                    hasProjector = Room.Room_HasProjector,
                    isLocked = Room.Room_IsLocked
                };

                result.userMessage = string.Format("Room {0} was found successfully.", roomReturned.name);
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: GetRoomById() method executed successfully.";
                result.result_set = roomReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the room provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: GetRoomById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Room_ResultSet>> UpdateRoom(int id, string name, string building, string buildingAddress, int capacity, int type, int computersCount, bool hasProjector, bool isLocked)
        {
            Generic_ResultSet<Room_ResultSet> result = new Generic_ResultSet<Room_ResultSet>();
            try
            {
                Room Room = new Room
                {
                    Room_ID = id,
                    Room_Name = name,
                    Room_Building = building,
                    Room_BuildingAddress = buildingAddress,
                    Room_Capacity = capacity,
                    Room_Type = type,
                    Room_ComputersCount = computersCount,
                    Room_HasProjector = hasProjector,
                    Room_IsLocked = isLocked
                };

                Room = await _crud.Update<Room>(Room, id);

                if (Room == null)
                {
                    throw new Exception();
                }

                Room_ResultSet roomUpdated = new Room_ResultSet
                {
                    id = Room.Room_ID,
                    name = Room.Room_Name,
                    building = Room.Room_Building,
                    buildingAddress = Room.Room_BuildingAddress,
                    capacity = Room.Room_Capacity,
                    type = Room.Room_Type,
                    computersCount = Room.Room_ComputersCount,
                    hasProjector = Room.Room_HasProjector,
                    isLocked = Room.Room_IsLocked
                };

                result.userMessage = string.Format("The provided room {0} was updated successfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: UpdateRoom() method executed successfully.";
                result.result_set = roomUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the room provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: UpdateRoom(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteRoom(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                bool roomDeleted = await _crud.Delete<Room>(id);

                if (!roomDeleted)
                {
                    throw new Exception();
                }

                result.userMessage = string.Format("The room with ID {0} was deleted successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: DeleteRoom() method executed successfully.";
                result.result_set = roomDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the room provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: DeleteRoom(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Room_ResultSet>>> GetRoomsByDayAvailable(int day)
        {
            Generic_ResultSet<List<Room_ResultSet>> result = new Generic_ResultSet<List<Room_ResultSet>>();
            try
            {
                List<Room> Rooms = await _extraFunctions.FilterRoomByDay(day);

                result.result_set = new List<Room_ResultSet>();
                Rooms.ForEach(dr => {
                    result.result_set.Add(new Room_ResultSet
                    {
                        id = dr.Room_ID,
                        name = dr.Room_Name,
                        building = dr.Room_Building,
                        buildingAddress = dr.Room_BuildingAddress,
                        capacity = dr.Room_Capacity,
                        type = dr.Room_Type,
                        computersCount = dr.Room_ComputersCount,
                        hasProjector = dr.Room_HasProjector,
                        isLocked = dr.Room_IsLocked
                    });
                });

                result.userMessage = string.Format("All rooms available for selected day obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: GetRoomsByDayAvailable() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required rooms from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: GetRoomsByDayAvailable(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Room_ResultSet>>> GetRoomsByTimeAvailable(int startTime, int endTime)
        {
            Generic_ResultSet<List<Room_ResultSet>> result = new Generic_ResultSet<List<Room_ResultSet>>();
            try
            {
                List<Room> Rooms = await _extraFunctions.FilterRoomByTime(startTime, endTime);

                result.result_set = new List<Room_ResultSet>();
                Rooms.ForEach(dr => {
                    result.result_set.Add(new Room_ResultSet
                    {
                        id = dr.Room_ID,
                        name = dr.Room_Name,
                        building = dr.Room_Building,
                        buildingAddress = dr.Room_BuildingAddress,
                        capacity = dr.Room_Capacity,
                        type = dr.Room_Type,
                        computersCount = dr.Room_ComputersCount,
                        hasProjector = dr.Room_HasProjector,
                        isLocked = dr.Room_IsLocked
                    });
                });

                result.userMessage = string.Format("All rooms available for selected time obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: GetRoomsByTimeAvailable() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required rooms from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: GetRoomsByTimeAvailable(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Room_ResultSet>>> GetRoomsByCapacity(int minCapacity)
        {
            Generic_ResultSet<List<Room_ResultSet>> result = new Generic_ResultSet<List<Room_ResultSet>>();
            try
            {
                List<Room> Rooms = await _extraFunctions.FilterRoomByCapacity(minCapacity);

                result.result_set = new List<Room_ResultSet>();
                Rooms.ForEach(dr => {
                    result.result_set.Add(new Room_ResultSet
                    {
                        id = dr.Room_ID,
                        name = dr.Room_Name,
                        building = dr.Room_Building,
                        buildingAddress = dr.Room_BuildingAddress,
                        capacity = dr.Room_Capacity,
                        type = dr.Room_Type,
                        computersCount = dr.Room_ComputersCount,
                        hasProjector = dr.Room_HasProjector,
                        isLocked = dr.Room_IsLocked
                    });
                });

                result.userMessage = string.Format("All rooms with selected capacity obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Room_Service: GetRoomsByCapacity() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required rooms from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Room_Service: GetRoomsByCapacity(): {0}", exception.Message);
            }
            return result;
        }
    }
}