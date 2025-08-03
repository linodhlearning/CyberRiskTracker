# 🛡️ Cyber Risk Info — Blazor Web App

A Blazor-powered web application for managing and visualizing cybersecurity risks in digital transformation projects, cloud infrastructure, and IT environments.

This tool providers information around 30+ industry-standard risks (e.g., OWASP Top 10, CWE, Insider Threats, Cloud Misconfigurations), all with clean UI components using Bootstrap and hosted image assets.

---

## 🚀 Features

- View, add, edit, and delete cybersecurity risks
- Searchable, responsive grid interface (WIP)
- Local image preview with fallback
- Modular repository pattern with support for:
  - In-memory SQL database (default)
  - Azure Blob storage (optional)
- Seeded top 30+ risks: OWASP, Network, Azure, API, Identity

---

## 🧰 Technologies Used

| Area                  | Tech Stack                                |
|-----------------------|--------------------------------------------|
| Frontend              | Blazor (.NET 9) with Bootstrap 5           |
| Rendering Mode        | Blazor **Interactive Server Auto** mode    |
| Data Persistence      | Entity Framework Core (InMemory provider)  |
| Alternative Storage   | Azure Blob Storage                         |
| Component Design      | Razor Components with Bootstrap styling    |
| Dependency Injection  | Built-in ASP.NET Core DI container         |

---

## 🛠️ Setup Instructions

### 1. Clone & Build 
```bash
git clone https://github.com/linodhlearning/cyber-risk-tracker.git
cd cyber-risk-tracker
dotnet restore
dotnet build
dotnet run
```
### 2.   Run the Application
```bash
dotnet run
```
