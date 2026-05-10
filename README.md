# GC — Group Chat API

ASP.NET Core 8 Web API solution for a group-chat style backend: domain models for users, groups, messages, and calls, plus REST controllers and an infrastructure layer with repository and service patterns (Entity Framework Core).

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or VS Code (optional), or any editor with the SDK installed

## Repository layout

If you cloned or extracted an archive, project files may live under a nested folder:

| Path | Contents |
|------|----------|
| `GC.Sln-master/` | Solution file `GC.Sln.sln` and all projects — **use this folder** for build and run commands |
| `GC/` | Web API host (`Program.cs`, controllers, Swagger) |
| `DBmodels/` | Entity models (`User`, `Group`, `Message`, `Member`, `Call`, etc.) |
| `Infrastructure/` | Repositories, services, EF Core packages |

Solution folders in Visual Studio group **GroupChat** (API), **DbModels**, and **Infrastructure**.

## Build

From the folder that contains `GC.Sln.sln`:

```bash
dotnet restore
dotnet build GC.Sln.sln
```

## Run (development)

```bash
dotnet run --project GC/GC.csproj
```

Or open `GC.Sln.sln` in Visual Studio and start the **GC** project.

- **HTTP:** `http://localhost:5041`
- **HTTPS:** `https://localhost:7136` (when using the `https` launch profile)

Swagger UI is enabled in Development and opens at `/swagger` (see `GC/Properties/launchSettings.json`).

## API surface

- **Swagger:** `/swagger` (Development only)
- **Sample endpoint:** `GET /weatherforecast` (template controller)
- **Planned areas:** `api/user`, `api/group`, `api/message` — controllers exist under `GC/Controllers/` and can be extended alongside `Infrastructure` services and repositories

## Configuration

App settings: `GC/appsettings.json` and `GC/appsettings.Development.json`.

---

*Target framework: .NET 8.0 (`net8.0`).*
