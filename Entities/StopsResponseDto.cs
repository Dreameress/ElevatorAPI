namespace ElevatorAPI.Entities
{
    public class StopsResponseDto
    {
        public int ElevatorId { get; set; }
        public List<int> Stops { get; set; } = new();

    }
}
