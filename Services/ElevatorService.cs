using ElevatorAPI.Entities;
using ElevatorAPI.Models;

namespace ElevatorAPI.Services
{
    public class ElevatorService : IElevatorService
    {
        private readonly IElevatorRepository _repository;

        public ElevatorService(IElevatorRepository repository)
        {
            _repository = repository;
        }

        public ElevatorCar CallElevator(int floor)
        {
            var bank = _repository.GetGroup();
            if (bank.Elevators.Count == 0)
            {
                throw new InvalidOperationException("No elevators available.");
            }

            // Choose the elevator closest to the requested floor.
            var chosen = bank.Elevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
                .First();

            // Use dictionary as a set: key = floor, value = true.
            chosen.Stops[floor] = true;

            return chosen;
        }

        public void RequestFloor(int elevatorId, int destinationFloor)
        {
            var elevator = _repository.GetElevator(elevatorId)
                ?? throw new InvalidOperationException($"Elevator {elevatorId} not found.");

            elevator.Stops[destinationFloor] = true;
        }

        public IReadOnlyCollection<int> GetStops(int elevatorId)
        {
            var elevator = _repository.GetElevator(elevatorId)
                ?? throw new InvalidOperationException($"Elevator {elevatorId} not found.");

            return elevator.Stops.Keys
                .OrderBy(f => f)
                .ToArray();
        }

        public int? GetNextStop(int elevatorId)
        {
            var elevator = _repository.GetElevator(elevatorId)
                ?? throw new InvalidOperationException($"Elevator {elevatorId} not found.");

            if (!elevator.Stops.Any())
            {
                return null;
            }

            // For simplicity: pick the closest floor to the current floor.
            var next = elevator.Stops.Keys
                .OrderBy(f => Math.Abs(f - elevator.CurrentFloor))
                .First();

            return next;
        }
    }
}