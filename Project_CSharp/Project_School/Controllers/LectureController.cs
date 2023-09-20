using DAL.Entities;
using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Lecture;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private ILecture_Service _lecture_Service;

        public LectureController(ILecture_Service lecture_Service)
        {
            _lecture_Service = lecture_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddLecture(Lecture_Pass_Object lecture)
        {
            var result = await _lecture_Service.AddLecture(lecture.type, lecture.courseId, lecture.courseName, lecture.semester, lecture.department, lecture.totalHours);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLectures()
        {
            var result = await _lecture_Service.GetAllLectures();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLectureById(int id)
        {
            var result = await _lecture_Service.GetLectureById(id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLecture(LectureUpdate_Pass_Object lecture)
        {
            var result = await _lecture_Service.UpdateLecture(lecture.id, lecture.type, lecture.courseId, lecture.courseName, lecture.semester, lecture.department, lecture.totalHours);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteLecture(int id)
        {
            var result = await _lecture_Service.DeleteLecture(id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
