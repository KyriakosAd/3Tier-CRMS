using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.TeacherLecture;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherLectureController : ControllerBase
    {
        private ITeacherLecture_Service _teacherLecture_Service;

        public TeacherLectureController(ITeacherLecture_Service teacherLecture_Service)
        {
            _teacherLecture_Service = teacherLecture_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddTeacherLecture(TeacherLecture_Pass_Object teacherLecture)
        {
            var result = await _teacherLecture_Service.AddTeacherLecture(teacherLecture.teacherId, teacherLecture.lectureId);
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
        public async Task<IActionResult> GetTeachersOfLecture(int id)
        {
            var result = await _teacherLecture_Service.GetTeachersOfLecture(id);
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
