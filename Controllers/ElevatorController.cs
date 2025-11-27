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

            var elevator = _service.CallElevator(request.Floor);

            return Ok(new
            {
                elevatorId = elevator.Id,
                elevator.CurrentFloor
            });
        }

        // A person requests that they be brought to a floor
        // POST api/v1/elevators/destination
        [HttpPost("destination")]
        public ActionResult RequestDestination([FromBody] RequestFloorDto request)
        {
            if (request == null)
            {
                return BadRequest("Request body is required.");
            }

            _service.RequestFloor(request.ElevatorId, request.DestinationFloor);
            return Accepted();
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

        // An elevator car requests the next floor it needs to service
        // GET api/v1/elevators/{id}/next-stop
        [HttpGet("{elevatorId:int}/next-stop")]
        public ActionResult<NextStopDto> GetNextStop(int elevatorId)
        {
            var next = _service.GetNextStop(elevatorId);

            return Ok(new NextStopDto
            {
                ElevatorId = elevatorId,
                NextStop = next
            });
        }
    }
}