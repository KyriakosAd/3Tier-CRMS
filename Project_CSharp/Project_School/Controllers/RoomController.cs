using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Room;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoom_Service _room_Service;

        public RoomController(IRoom_Service room_Service)
        {
            _room_Service = room_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddRoom(Room_Pass_Object room)
        {
            var result = await _room_Service.AddRoom(room.name, room.building, room.buildingAddress, room.capacity, room.type, room.computersCount, room.hasProjector, room.isLocked);
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
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await _room_Service.GetAllRooms();
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
        public async Task<IActionResult> GetRoomById(int id)
        {
            var result = await _room_Service.GetRoomById(id);
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
        public async Task<IActionResult> UpdateRoom(RoomUpdate_Pass_Object room)
        {
            var result = await _room_Service.UpdateRoom(room.id, room.name, room.building, room.buildingAddress, room.capacity, room.type, room.computersCount, room.hasProjector, room.isLocked);
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
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _room_Service.DeleteRoom(id);
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
        public async Task<IActionResult> GetRoomsByDayAvailable(int day)
        {
            var result = await _room_Service.GetRoomsByDayAvailable(day);
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
        public async Task<IActionResult> GetRoomsByTimeAvailable(int startTime, int endTime)
        {
            var result = await _room_Service.GetRoomsByTimeAvailable(startTime, endTime);
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
        public async Task<IActionResult> GetRoomsByCapacity(int minCapacity)
        {
            var result = await _room_Service.GetRoomsByCapacity(minCapacity);
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
