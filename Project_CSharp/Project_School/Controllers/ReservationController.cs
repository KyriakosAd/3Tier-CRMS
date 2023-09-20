using DAL.Entities;
using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Reservation;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservation_Service _reservation_Service;

        public ReservationController(IReservation_Service reservation_Service)
        {
            _reservation_Service = reservation_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddReservation(Reservation_Pass_Object reservation)
        {
            var result = await _reservation_Service.AddReservation(reservation.entryDate, reservation.isRecurring, reservation.startDate, reservation.endDate, reservation.exactDate, reservation.day, reservation.startTime, reservation.endTime, reservation.roomId);
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
        public async Task<IActionResult> GetAllReservations()
        {
            var result = await _reservation_Service.GetAllReservations();
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
        public async Task<IActionResult> GetReservationsByRoom(int roomId)
        {
            var result = await _reservation_Service.GetReservationsByRoom(roomId);
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
        public async Task<IActionResult> GetReservationById(int id)
        {
            var result = await _reservation_Service.GetReservationById(id);
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
        public async Task<IActionResult> UpdateReservation(ReservationUpdate_Pass_Object reservation)
        {
            var result = await _reservation_Service.UpdateReservation(reservation.id, reservation.entryDate, reservation.isRecurring, reservation.startDate, reservation.endDate, reservation.exactDate, reservation.day, reservation.startTime, reservation.endTime, reservation.roomId);
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
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var result = await _reservation_Service.DeleteReservation(id);
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
