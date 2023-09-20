using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class ExtraFunctions : IExtraFunctions
    {
        public async Task<List<Room>> FilterRoomByDay(int day)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<int> roomIdsForDay = await context.RoomAvailabilities
                        .Where(ra => ra.RoomAvailability_Day == day)
                        .Select(ra => ra.Room_ID)
                        .Distinct()
                        .ToListAsync();

                    List<Room> rooms = await context.Rooms
                        .Where(r => roomIdsForDay.Contains(r.Room_ID))
                        .ToListAsync();

                    return rooms;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Room>> FilterRoomByTime(int startTime, int endTime)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<int> roomIdsForDay = await context.RoomAvailabilities
                        .Where(ra => (ra.RoomAvailability_StartTime <= startTime && ra.RoomAvailability_EndTime >= endTime))
                        .Select(ra => ra.Room_ID)
                        .Distinct()
                        .ToListAsync();

                    List<Room> rooms = await context.Rooms
                        .Where(r => roomIdsForDay.Contains(r.Room_ID))
                        .ToListAsync();

                    return rooms;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Room>> FilterRoomByCapacity(int minCapacity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<Room> rooms = await context.Rooms
                        .Where(r => r.Room_Capacity >= minCapacity)
                        .Distinct()
                        .ToListAsync();

                    return rooms;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RoomAvailability>> GetAvailabilitiesFromRoom(int roomId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<RoomAvailability> roomAvailabilities = await context.RoomAvailabilities
                        .Where(r => r.Room_ID == roomId)
                        .Distinct()
                        .ToListAsync();

                    return roomAvailabilities;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Reservation>> GetReservationsFromRoom(int roomId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<Reservation> reservations = await context.Reservations
                        .Where(r => r.Room_ID == roomId)
                        .Distinct()
                        .ToListAsync();

                    return reservations;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Teacher>> GetTeachersFromLecture(int lectureId)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<int> teacherIdsFromLecture = await context.TeacherLectures
                        .Where(tl => (tl.Lecture_ID == lectureId))
                        .Select(tl => tl.Teacher_ID)
                        .Distinct()
                        .ToListAsync();

                    List<Teacher> teachers = await context.Teachers
                        .Where(t => teacherIdsFromLecture.Contains(t.Teacher_ID))
                        .ToListAsync();

                    return teachers;
                }
            }
            catch
            {
                throw;
            }
        }
    }

}