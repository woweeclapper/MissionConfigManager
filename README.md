# 🚀Mission Data Config Manager

a lightweight backend service that ingests mission configuration XML files, parses them into strongly typed domain models, persists them into a SQLite database, and exposes them through a clean JSON API.


## 🧩 Project Overview
## Features

- Parse mission configuration from XML
- Validate and map XML → C# models
- Store data in a SQL database using EF Core
- Expose REST endpoints to query mission data
- Include unit tests for the XML parser


## Tech Stack
- C#
- .NET 8 Web API
- Entity Framework Core
- SQLite or PostgreSQL
- XML serialization/deserialization


## 📁 Project Structure
```
MissionConfigManager/
│── MissionConfigManager.Api/        # Web API
│── MissionConfigManager.Core/       # Models + XML parser
│── MissionConfigManager.Data/       # EF Core DbContext
│── MissionConfigManager.Tests/      # Unit tests
│── sample-config.xml                # Example NASA-style XML
```

## Usage/Examples

Example for `sample-config.xml`
```
<MissionConfig>
  <Module name="PowerSystem">
    <Parameter key="Voltage" value="120" />
    <Parameter key="Current" value="15" />
  </Module>

  <Module name="LifeSupport">
    <Parameter key="OxygenLevel" value="98" />
    <Parameter key="CO2Level" value="2" />
  </Module>
</MissionConfig>

```


## Database
SQLite database located in the Data project:
```
MissionConfigManager.Data/mission.db
```
- EF Core handles:
- Module storage
- Parameter storage
- Relationships
- Migrations (optional)


## Running Tests

From the .Api Project Folder

```powershell
dotnet run
```
You should see:
```
Now listening on: http://localhost:XXXX
```



## Endpoints

#### Request:
```bash
curl -X POST http://localhost:XXXX/import-xml -F "file=@sample-config.xml"

```
Uploads and imports an XML mission configuration file. 
### DO IT WITHIN THE API FOLDER

#### Response
```
{ "Imported": 2 (or whatever your sample have) }
```

```
GET /modules
```
#### Response Example:
```
[
  {
    "id": 1,
    "name": "PowerSystem",
    "parameters": [
      { "key": "Voltage", "value": "120" },
      { "key": "Current", "value": "15" }
    ]
  }
]
```


## Future Enhancement (prob)

- Add module search/filter endpoints
- Add versioning for multiple XML imports
- Add a small UI dashboard (React or Blazor)
- Add authentication for protected mission configs
