# ElevatorAPI
Elevator API to allow for Riders to select floors, and the system to
monitor and manage elevator interations
## Developed by Sabrina Smith 11/26/25

## Requirements 
- .NET CORE 8 SDK 
- VsCode or Visual Studio 
- Git / Terminal

## Running the API

From the root folder `ElevatorAPI` do the following:

- Open Git Bash or Terminal 
- type the following commands: 
- dotnet restore
- dotnet run

OR
 
- Open the folder in Visual Studio 
- Find the debug panel (located near the underside fothe help tab) and select the `https` option

- The app is configured to listen on https://localhost:7292

## Sample Calls

POST	api/v1/elevator/call 
json: 
`{
	"floor" : 3
}`

GET		api/v1/elevator/{elevatorId}/stops

POST	api/v1/elevator/desination
json: 
`{
	"elevatorId": 1,
	"destinationFloor": 10
 }`

GET		api/v1/elevator/{elevatorId}/next-stop


## Testing 
- From the ElevatorAPI.Tests folder open Git
- type `dotnet test` and press enter

OR

- Open Elevator Service Tests in Visual Studio
- Right click and select Run Tests or Select Run All Tests from the Test Tab in the Top Level Menu



