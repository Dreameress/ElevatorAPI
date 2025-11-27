using ElevatorAPI.Models;

namespace ElevatorAPI.Entities
{
    public class InMemoryElevatorRepository : IElevatorRepository
    {
       //Set up Dummy Data
        public InMemoryElevatorRepository()
        {
            _group = new ElevatorGroup(
                id: 1,
                elevators: new[]
                {
                new ElevatorCar(1, startingFloor: 1),
                new ElevatorCar(2, startingFloor: 5),
                new ElevatorCar(3, startingFloor: 10)
                });
        }

        private readonly ElevatorGroup _group;
        public ElevatorGroup GetGroup() => _group;

        public ElevatorCar? GetElevator(int elevatorId)
        {
            return _group.Elevators.FirstOrDefault(e => e.Id == elevatorId);
        }
    }
}
