# TenantProject

**TenantProject** is a simple ASP.NET Core Web API for managing tenants, types and login/auth using JWT. The project is built with .NET 8, Entity Framework Core and PostgreSQL, and supports running locally or via Docker (Docker Compose).

---

## 🔧 Features

- Tenant creation and retrieval via `/api/Tenant`
- Tenant types listing via `/api/Tenant/Types`
- EF Core migrations and PostgreSQL support
- Docker and docker-compose configuration for easy deployment

---

## 🧩 Tech stack

- .NET 8 (ASP.NET Core)
- Entity Framework Core
- PostgreSQL
- Docker / Docker Compose

---

## ⚙️ Prerequisites

- .NET 8 SDK
- (Optional) Docker & Docker Compose
- (Optional) PostgreSQL server (if you don't use Dockerized DB)
- (Optional) `dotnet-ef` tool for migrations: `dotnet tool install --global dotnet-ef`

---

## 🚀 Quick start

### Run locally (Development)

1. Open the solution folder and set your connection string in `appsettings.Development.json` or set an environment variable `ConnectionStrings__MainConnectionString`.

2. Run the app from the `TenantProject` folder:

```bash
dotnet run --project TenantProject.csproj
```

3. By default the project uses the URLs configured in `Properties/launchSettings.json` (e.g. `http://localhost:5001` and `https://localhost:7211`). Swagger is available at `/swagger`.

### Run with Docker Compose

The included `docker-compose.yaml` provides an easy way to run the app with environment variables configured. Example:

```bash
docker compose up --build
```

The compose file maps container port `8080` to host port `5003` (see `docker-compose.yaml`), so the API will be available at `http://localhost:5003/swagger`.

> NOTE: The compose file includes environment variable placeholders. Avoid committing secrets; use a secure secret store or environment overrides in CI.

---

## 🔐 Configuration & Environment variables

Important env vars used by the app (set via env or `appsettings*.json`):

- `ConnectionStrings__MainConnectionString` — PostgreSQL connection string
- `Jwt__Key` — Secret key used to sign JWT tokens
- `Jwt__Issuer` — JWT issuer value
- `AllowedOrigins__0` — Allowed CORS origin(s)

You can set them in your environment, Docker Compose file, or `appsettings.Development.json` for local development.

---

## 🗄️ Database & Migrations

This project uses EF Core migrations (the repository already contains migration files under `Migrations/`).

To add or apply migrations locally:

```bash
# Add migration (if you change model)
dotnet ef migrations add YourMigrationName --project TenantProject.csproj

# Apply pending migrations to the database
dotnet ef database update --project TenantProject.csproj
```

Make sure `ConnectionStrings__MainConnectionString` points to your PostgreSQL instance.

---

## 📡 API Endpoints

Base path: `/api`


- POST `/api/Tenant` — Create a tenant
  - Body: `TenantRequestDto` (fields: `tenantName`, `tenantTypeId`, `tenantPhone`, `tenantAddress`, `boothNum?`, `areaSm?`)
  - Example:

```bash
curl -X POST http://localhost:5001/api/Tenant \
  -H "Content-Type: application/json" \
  -d '{"tenantName":"My Booth","tenantTypeId":"<GUID>","tenantPhone":"0812345678","tenantAddress":"Hall A","boothNum":"A1","areaSm":12}'
```

- GET `/api/Tenant` — Get tenant list (optional `search` query string)
- GET `/api/Tenant/Types` — Get tenant type list

---

## 🛠 Development notes

- Services are registered via `Services/ServiceExtensions.cs`.
- Validation attributes are applied on DTOs (e.g. `TenantRequestDto`).

---

## ✅ Contributing

Contributions are welcome. Please open issues or PRs with clear descriptions. Follow the standard workflow:

1. Fork the repo
2. Create a feature branch
3. Add tests (if applicable)
4. Open a PR

---

## 📄 License

Specify your license here (e.g. MIT). If you don't want a license, remove this section.

---

## ✉️ Contact

For questions or help, please open an issue or contact the repository owner.

---

Thank you for using TenantProject! 🔧🎯
