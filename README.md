# NexusCRM 🚀

### A SaaS CRM Platform for Small Businesses

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=flat-square&logo=dotnet)
![EF Core](https://img.shields.io/badge/EF_Core-10.0-512BD4?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=flat-square&logo=microsoftsqlserver)
![JWT](https://img.shields.io/badge/Auth-JWT-000000?style=flat-square&logo=jsonwebtokens)
![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?style=flat-square&logo=docker)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

---

## 📖 Overview

NexusCRM is a cloud-based, multi-tenant CRM platform designed for small and medium-sized businesses to manage clients, employees, tasks, invoices, and business workflows in one centralized system.

Each company operates in a fully isolated workspace — built with security, scalability, and clean architecture in mind.

---

## ✨ Features

- 🏢 **Multi-Tenant Architecture** — isolated data per company
- 🔐 **JWT Authentication** with Refresh Tokens
- 👥 **Role-Based Authorization** — SuperAdmin, CompanyAdmin, Employee
- 📋 **Client & Lead Management**
- ✅ **Task Management** with Kanban-style workflow
- 🧾 **Invoice & Billing** with PDF export
- 🔔 **Notification System** with background jobs
- 📁 **File Management** with secure access
- 📊 **Analytics Dashboard**
- 📜 **Audit Logs & Request Logging**
- ⚡ **Redis Caching & Query Optimization**
- 🐳 **Dockerized Deployment**

---

## 🏗️ Architecture

NexusCRM follows **Clean Architecture** principles:

```
NexusCRM/
├── NexusCRM.API/               # Entry point — Controllers, Middleware
├── NexusCRM.Application/       # Business Logic — DTOs, Interfaces, Services
├── NexusCRM.Domain/            # Core — Entities, Enums, Contracts
└── NexusCRM.Infrastructure/    # External — EF Core, JWT, Repositories
```

### Dependency Flow

```
API → Application → Domain
Infrastructure → Application → Domain
```

> The Domain layer has zero external dependencies — pure C# business rules.

---

## 🛠️ Tech Stack

| Layer            | Technology                           |
| ---------------- | ------------------------------------ |
| Framework        | ASP.NET Core 8 Web API               |
| Database         | SQL Server + Entity Framework Core 8 |
| Authentication   | JWT Bearer + Refresh Tokens          |
| Password Hashing | BCrypt.Net                           |
| Validation       | FluentValidation                     |
| Mapping          | AutoMapper                           |
| Background Jobs  | Hangfire                             |
| Logging          | Serilog                              |
| Caching          | Redis                                |
| Containerization | Docker + Docker Compose              |
| API Docs         | Swagger / OpenAPI                    |

---

## 👤 User Roles

| Role             | Description                                                     |
| ---------------- | --------------------------------------------------------------- |
| **SuperAdmin**   | Platform owner — manages all tenants, subscriptions, audit logs |
| **CompanyAdmin** | Company owner — manages employees, clients, invoices, reports   |
| **Employee**     | Regular worker — manages assigned tasks, client notes, files    |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or later
- [Docker](https://www.docker.com/) _(optional)_

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/NexusCRM.git
cd NexusCRM
```

### 2. Configure Connection String

In `NexusCRM.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=NexusCRMDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "JwtSettings": {
    "Secret": "YOUR_SECRET_KEY_MIN_32_CHARS",
    "Issuer": "NexusCRM",
    "Audience": "NexusCRMUsers",
    "AccessTokenExpiryMinutes": 15,
    "RefreshTokenExpiryDays": 7
  }
}
```

### 3. Apply Migrations

```bash
cd NexusCRM.API
dotnet ef database update --project ../NexusCRM.Infrastructure
```

Or via Visual Studio Package Manager Console:

```powershell
Update-Database -StartupProject NexusCRM.API
```

### 4. Run the Application

```bash
dotnet run --project NexusCRM.API
```

API will be available at `https://localhost:{port}/swagger`

---

## 🐳 Docker

```bash
docker-compose up --build
```

> Docker Compose setup coming in Phase 12.

---

## 📡 API Endpoints

### Authentication

| Method | Endpoint                  | Description                  | Auth   |
| ------ | ------------------------- | ---------------------------- | ------ |
| POST   | `/api/auth/register`      | Register new company + admin | Public |
| POST   | `/api/auth/login`         | Login and get tokens         | Public |
| POST   | `/api/auth/refresh-token` | Refresh access token         | Public |

> More endpoints will be added as each phase is completed.

---

## 📦 Project Phases

| Phase | Description                         | Status         |
| ----- | ----------------------------------- | -------------- |
| 1     | Project Foundation & Authentication | ✅ Complete    |
| 2     | Multi-Tenant System                 | 🔄 In Progress |
| 3     | Employee & Role Management          | ⏳ Planned     |
| 4     | Client Management Module            | ⏳ Planned     |
| 5     | Task Management System              | ⏳ Planned     |
| 6     | Invoice & Billing Module            | ⏳ Planned     |
| 7     | Notifications System                | ⏳ Planned     |
| 8     | File Management                     | ⏳ Planned     |
| 9     | Analytics Dashboard                 | ⏳ Planned     |
| 10    | Logging & Monitoring                | ⏳ Planned     |
| 11    | Optimization & Scaling              | ⏳ Planned     |
| 12    | Deployment & DevOps                 | ⏳ Planned     |

---

## 🗄️ Database Entities

```
Users, Companies, Roles, Permissions,
Clients, Tasks, TaskComments,
Invoices, InvoiceItems,
Notifications, ActivityLogs, Files
```

---

## 🔒 Security

- Passwords hashed with **BCrypt**
- Access tokens expire in **15 minutes**
- Refresh tokens expire in **7 days**
- Global exception middleware — no stack traces exposed
- Soft delete on all entities — no permanent data loss
- Tenant isolation — companies cannot access each other's data

---

## 🤝 Contributing

This project is currently in active development. Contributions, issues, and feature requests are welcome!

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m 'Add my feature'`
4. Push to the branch: `git push origin feature/my-feature`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

<div align="center">
  Built with ❤️ using ASP.NET Core 8
</div>
