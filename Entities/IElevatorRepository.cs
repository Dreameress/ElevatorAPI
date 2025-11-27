using ElevatorAPI.Models;

namespace ElevatorAPI.Entities
{
    public interface IElevatorRepository
    {
        ElevatorGroup GetGroup();
        ElevatorCar? GetElevator(int elevatorId);
    }
}
