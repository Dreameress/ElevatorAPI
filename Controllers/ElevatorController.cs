using ElevatorAPI.Entities;
using ElevatorAPI.Models;
using ElevatorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorService _service;

        public ElevatorController(IElevatorService service)
        {
            _service = service;
        }

        // A person requests an elevator be sent to their current floor
        // POST api/v1/elevators/call
        [HttpPost("call")]
        public ActionResult CallElevator([FromBody] ElevatorCallRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Request body is required.");
            }

            var elevator = new ElevatorCar(1);//_service.CallElevator(request.Floor);

            return Ok(new
            {
                elevatorId = elevator.Id,
                elevator.CurrentFloor
            });
        }


        // An elevator car requests all floors that current passengers are servicing
        // GET api/v1/elevators/{id}/stops
        [HttpGet("{elevatorId:int}/stops")]
        public ActionResult<StopsResponseDto> GetStops(int elevatorId)
        {
            var stops = _service.GetStops(elevatorId);

            return Ok(new StopsResponseDto
            {
                ElevatorId = elevatorId,
                Stops = stops.ToList()
            });
        }


    }
}