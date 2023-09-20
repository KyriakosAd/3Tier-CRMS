using DAL.Entities;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC.Services.Interfaces;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Models.TeacherLecture;
using LOGIC.Services.Models.Teacher;

namespace LOGIC.Services.Implementation
{
    public class TeacherLecture_Service: ITeacherLecture_Service
    {
        private ICRUD _crud = new CRUD();
        private IExtraFunctions _extraFunctions = new ExtraFunctions();

        public async Task<Generic_ResultSet<TeacherLecture_ResultSet>> AddTeacherLecture(int teacherId, int lectureId)
        {
            Generic_ResultSet<TeacherLecture_ResultSet> result = new Generic_ResultSet<TeacherLecture_ResultSet>();
            try
            {
                TeacherLecture TeacherLecture = new TeacherLecture
                {
                    Teacher_ID = teacherId,
                    Lecture_ID = lectureId
                };

                TeacherLecture = await _crud.Create<TeacherLecture>(TeacherLecture);

                TeacherLecture_ResultSet teacherLectureAdded = new TeacherLecture_ResultSet
                {
                    teacherId = TeacherLecture.Teacher_ID,
                    lectureId = TeacherLecture.Lecture_ID
                };

                result.userMessage = string.Format("The provided teacher - lecture was added successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.TeacherLecture_Service: AddTeacherLecture() method executed successfully.";
                result.result_set = teacherLectureAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the teacher - lecture provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.TeacherLecture_Service: AddTeacherLecture(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetTeachersOfLecture(int lectureId)
        {
            Generic_ResultSet<List<Teacher_ResultSet>> result = new Generic_ResultSet<List<Teacher_ResultSet>>();
            try
            {
                List<Teacher> Teachers = await _extraFunctions.GetTeachersFromLecture(lectureId);

                result.result_set = new List<Teacher_ResultSet>();
                Teachers.ForEach(dr => {
                    result.result_set.Add(new Teacher_ResultSet
                    {
                        id = dr.Teacher_ID,
                        name = dr.Teacher_Name,
                        type = dr.Teacher_Type,
                        userId = dr.User_ID
                    });
                });

                result.userMessage = string.Format("All teachers for selected lecture obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.TeacherLecture_Service: GetTeachersOfLecture() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required teachers from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.TeacherLecture_Service: GetTeachersOfLecture(): {0}", exception.Message);
            }
            return result;
        }
    }
}
