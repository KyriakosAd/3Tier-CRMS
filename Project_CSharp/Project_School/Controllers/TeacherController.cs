using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Teacher;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacher_Service _teacher_Service;

        public TeacherController(ITeacher_Service teacher_Service)
        {
            _teacher_Service = teacher_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddTeacher(Teacher_Pass_Object teacher)
        {
            var result = await _teacher_Service.AddTeacher(teacher.name, teacher.type, teacher.userId);
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
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _teacher_Service.GetAllTeachers();
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
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var result = await _teacher_Service.GetTeacherById(id);
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
        public async Task<IActionResult> UpdateTeacher(TeacherUpdate_Pass_Object teacher)
        {
            var result = await _teacher_Service.UpdateTeacher(teacher.id, teacher.name, teacher.type, teacher.userId);
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
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacher_Service.DeleteTeacher(id);
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
