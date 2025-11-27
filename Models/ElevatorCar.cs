namespace ElevatorAPI.Models
{
    public class ElevatorCar
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public Direction SelectedDirection {get;set;}
        public Dictionary<int, bool> Stops { get; } = [];

        //set default construtor and values
        public ElevatorCar(int id, int startingFloor = 1) 
        {
            Id = id;
            CurrentFloor = startingFloor;
            SelectedDirection = Direction.NotMoving;
        }

    }
}
