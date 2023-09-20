using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.RoomAvailability;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAvailabilityController : ControllerBase
    {
        private IRoomAvailability_Service _roomAvailability_Service;

        public RoomAvailabilityController(IRoomAvailability_Service roomAvailability_Service)
        {
            _roomAvailability_Service = roomAvailability_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddRoomAvailability(RoomAvailability_Pass_Object roomAvailability)
        {
            var result = await _roomAvailability_Service.AddRoomAvailability(roomAvailability.day, roomAvailability.startTime, roomAvailability.endTime, roomAvailability.roomId);
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
        public async Task<IActionResult> GetRoomAvailabilitiesByRoom(int roomId)
        {
            var result = await _roomAvailability_Service.GetRoomAvailabilitiesByRoom(roomId);
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
        public async Task<IActionResult> UpdateRoomAvailability(RoomAvailabilityUpdate_Pass_Object roomAvailability)
        {
            var result = await _roomAvailability_Service.UpdateRoomAvailability(roomAvailability.id, roomAvailability.day, roomAvailability.startTime, roomAvailability.endTime, roomAvailability.roomId);
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
        public async Task<IActionResult> DeleteRoomAvailability(int id)
        {
            var result = await _roomAvailability_Service.DeleteRoomAvailability(id);
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
