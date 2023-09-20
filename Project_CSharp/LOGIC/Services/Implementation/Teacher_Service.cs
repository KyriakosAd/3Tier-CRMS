using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models.Teacher;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Teacher_Service : ITeacher_Service
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Teacher_ResultSet>> AddTeacher(string name, string type, int userId)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                Teacher Teacher = new Teacher
                {
                    Teacher_Name = name,
                    Teacher_Type = type,
                    User_ID = userId
                };

                Teacher = await _crud.Create<Teacher>(Teacher);

                Teacher_ResultSet teacherAdded = new Teacher_ResultSet
                {
                    id = Teacher.Teacher_ID,
                    name = Teacher.Teacher_Name,
                    type = Teacher.Teacher_Type,
                    userId = Teacher.User_ID
                };

                result.userMessage = string.Format("The provided teacher {0} was added successfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: AddTeacher() method executed successfully.";
                result.result_set = teacherAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the teacher provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: AddTeacher(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetAllTeachers()
        {
            Generic_ResultSet<List<Teacher_ResultSet>> result = new Generic_ResultSet<List<Teacher_ResultSet>>();
            try
            {
                List<Teacher> Teachers = await _crud.ReadAll<Teacher>();

                result.result_set = new List<Teacher_ResultSet>();
                Teachers.ForEach(du => {
                    result.result_set.Add(new Teacher_ResultSet
                    {
                        id = du.Teacher_ID,
                        name = du.Teacher_Name,
                        type = du.Teacher_Type,
                        userId = du.User_ID
                    });
                });

                result.userMessage = string.Format("All teachers obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: GetAllTeachers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required teachers from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: GetAllTeachers(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Teacher_ResultSet>> GetTeacherById(int id)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                Teacher Teacher = await _crud.Read<Teacher>(id);

                if (Teacher == null)
                {
                    throw new Exception();
                }

                Teacher_ResultSet teacherReturned = new Teacher_ResultSet
                {
                    id = Teacher.Teacher_ID,
                    name = Teacher.Teacher_Name,
                    type = Teacher.Teacher_Type,
                    userId = Teacher.User_ID
                };

                result.userMessage = string.Format("Teacher {0} was found successfully.", teacherReturned.name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: GetTeacherById() method executed successfully.";
                result.result_set = teacherReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the teacher provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: GetTeacherById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Teacher_ResultSet>> UpdateTeacher(int id, string name, string type, int userId)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                Teacher Teacher = new Teacher
                {
                    Teacher_ID = id,
                    Teacher_Name = name,
                    Teacher_Type = type,
                    User_ID = userId
                };

                Teacher = await _crud.Update<Teacher>(Teacher, id);

                if (Teacher == null)
                {
                    throw new Exception();
                }

                Teacher_ResultSet teacherUpdated = new Teacher_ResultSet
                {
                    id = Teacher.Teacher_ID,
                    name = Teacher.Teacher_Name,
                    type = Teacher.Teacher_Type,
                    userId = Teacher.User_ID
                };

                result.userMessage = string.Format("The provided teacher {0} was updated successfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: UpdateTeacher() method executed successfully.";
                result.result_set = teacherUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the teacher provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: UpdateTeacher(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteTeacher(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                bool teacherDeleted = await _crud.Delete<Teacher>(id);

                if (!teacherDeleted)
                {
                    throw new Exception();
                }

                result.userMessage = string.Format("The teacher with ID {0} was deleted successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: DeleteTeacher() method executed successfully.";
                result.result_set = teacherDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the teacher provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: DeleteTeacher(): {0}", exception.Message);
            }
            return result;
        }
    }
}
