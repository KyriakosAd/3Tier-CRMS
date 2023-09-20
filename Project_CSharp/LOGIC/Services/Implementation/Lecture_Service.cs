using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models.Lecture;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Lecture_Service : ILecture_Service
    {
        private ICRUD _crud = new CRUD();
        public async Task<Generic_ResultSet<Lecture_ResultSet>> AddLecture(string type, int courseId, string courseName, int semester, string department, int totalHours)
        {
            Generic_ResultSet<Lecture_ResultSet> result = new Generic_ResultSet<Lecture_ResultSet>();
            try
            {
                Lecture Lecture = new Lecture
                {
                    Lecture_Type = type,
                    Lecture_CourseID = courseId,
                    Lecture_CourseName = courseName,
                    Lecture_Semester = semester,
                    Lecture_Department = department,
                    Lecture_TotalHours = totalHours,
                };

                Lecture = await _crud.Create<Lecture>(Lecture);

                Lecture_ResultSet lectureAdded = new Lecture_ResultSet
                {
                    id = Lecture.Lecture_ID,
                    type = Lecture.Lecture_Type,
                    courseId = Lecture.Lecture_CourseID,
                    courseName = Lecture.Lecture_CourseName,
                    semester = Lecture.Lecture_Semester,
                    department = Lecture.Lecture_Department,
                    totalHours = Lecture.Lecture_TotalHours
                };

                result.userMessage = string.Format("The provided lecture was added successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Lecture_Service: AddLecture() method executed successfully.";
                result.result_set = lectureAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the lecture provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Lecture_Service: AddLecture(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Lecture_ResultSet>>> GetAllLectures()
        {
            Generic_ResultSet<List<Lecture_ResultSet>> result = new Generic_ResultSet<List<Lecture_ResultSet>>();
            try
            {
                List<Lecture> Lectures = await _crud.ReadAll<Lecture>();

                result.result_set = new List<Lecture_ResultSet>();
                Lectures.ForEach(du => {
                    result.result_set.Add(new Lecture_ResultSet
                    {
                        id = du.Lecture_ID,
                        type = du.Lecture_Type,
                        courseId = du.Lecture_CourseID,
                        courseName = du.Lecture_CourseName,
                        semester = du.Lecture_Semester,
                        department = du.Lecture_Department,
                        totalHours = du.Lecture_TotalHours
                    });
                });

                result.userMessage = string.Format("All lectures obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Lecture_Service: GetAllLectures() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required lectures from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Lecture_Service: GetAllLectures(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Lecture_ResultSet>> GetLectureById(int id)
        {
            Generic_ResultSet<Lecture_ResultSet> result = new Generic_ResultSet<Lecture_ResultSet>();
            try
            {
                Lecture Lecture = await _crud.Read<Lecture>(id);

                if (Lecture == null)
                {
                    throw new Exception();
                }

                Lecture_ResultSet lectureReturned = new Lecture_ResultSet
                {
                    id = Lecture.Lecture_ID,
                    type = Lecture.Lecture_Type,
                    courseId = Lecture.Lecture_CourseID,
                    courseName = Lecture.Lecture_CourseName,
                    semester = Lecture.Lecture_Semester,
                    department = Lecture.Lecture_Department,
                    totalHours = Lecture.Lecture_TotalHours
                };

                result.userMessage = string.Format("Lecture provided was found successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Lecture_Service: GetLectureById() method executed successfully.";
                result.result_set = lectureReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the lecture provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Lecture_Service: GetLectureById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Lecture_ResultSet>> UpdateLecture(int id, string type, int courseId, string courseName, int semester, string department, int totalHours)
        {
            Generic_ResultSet<Lecture_ResultSet> result = new Generic_ResultSet<Lecture_ResultSet>();
            try
            {
                Lecture Lecture = new Lecture
                {
                    Lecture_ID = id,
                    Lecture_Type = type,
                    Lecture_CourseID = courseId,
                    Lecture_CourseName = courseName,
                    Lecture_Semester = semester,
                    Lecture_Department = department,
                    Lecture_TotalHours = totalHours
                };

                Lecture = await _crud.Update<Lecture>(Lecture, id);

                if (Lecture == null)
                {
                    throw new Exception();
                }

                Lecture_ResultSet lectureUpdated = new Lecture_ResultSet
                {
                    id = Lecture.Lecture_ID,
                    type = Lecture.Lecture_Type,
                    courseId = Lecture.Lecture_CourseID,
                    courseName = Lecture.Lecture_CourseName,
                    semester = Lecture.Lecture_Semester,
                    department = Lecture.Lecture_Department,
                    totalHours = Lecture.Lecture_TotalHours
                };

                result.userMessage = string.Format("The provided lecture was updated successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.Lecture_Service: UpdateLecture() method executed successfully.";
                result.result_set = lectureUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the lecture provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Lecture_Service: UpdateLecture(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteLecture(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                bool lectureDeleted = await _crud.Delete<Lecture>(id);

                if (!lectureDeleted)
                {
                    throw new Exception();
                }

                result.userMessage = string.Format("The lecture with ID {0} was deleted successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.Lecture_Service: DeleteLecture() method executed successfully.";
                result.result_set = lectureDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the lecture provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Lecture_Service: DeleteLecture(): {0}", exception.Message);
            }
            return result;
        }
    }
}
