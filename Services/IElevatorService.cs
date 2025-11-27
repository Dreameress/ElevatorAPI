using ElevatorAPI.Models;

namespace ElevatorAPI.Services
{
    public interface IElevatorService
    {
        ElevatorCar CallElevator(int selectedFloor);
        void RequestFloor(int elevatorId, int selectedFloor);
        IReadOnlyCollection<int> GetStops(int elevatorId);
        int? GetNextStop(int elevatorId);
    }
}
