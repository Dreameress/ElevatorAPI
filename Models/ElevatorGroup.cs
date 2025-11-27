namespace ElevatorAPI.Models
{
    public class ElevatorGroup
    {
        public int Id { get; set; }
        public List<ElevatorCar> Elevators { get; } = [];
        public ElevatorGroup(int id, IEnumerable<ElevatorCar> elevators)
        {
            Id = id;
            if (elevators != null)
            {
                Elevators.AddRange(elevators);
            }
        }
    }
}
