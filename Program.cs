using ElevatorAPI.Entities;
using ElevatorAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddControllers();

// DI registrations
builder.Services.AddSingleton<IElevatorRepository, InMemoryElevatorRepository>();
builder.Services.AddSingleton<IElevatorService, ElevatorService>();

var app = builder.Build();

app.MapControllers();

// Minimal API pattern exposing the same functionality
var group = app.MapGroup("/api/v1/min/elevators");

group.MapPost("call", (ElevatorCallRequestDto request, IElevatorService service) =>
{
    var elevator = service.CallElevator(request.Floor);
    return Results.Ok(new
    {
        elevatorId = elevator.Id,
        elevator.CurrentFloor
    });
});



group.MapGet("{elevatorId:int}/stops", (int elevatorId, IElevatorService service) =>
{
    var stops = service.GetStops(elevatorId);
    var response = new StopsResponseDto
    {
        ElevatorId = elevatorId,
        Stops = stops.ToList()
    };
    return Results.Ok(response);
});


app.Run();