# DOTNET.Blazor_API

A full-stack web app using **Blazor** (frontend) and **ASP.NET Core Web API** (backend) for managing employee records.

## 🛠️ Technologies Used

- Blazor (Server)
- ASP.NET Core Web API
- Entity Framework Core (SQL Server)
- C#
- HTML/CSS

## 📋 Features

- Add, update, delete, and search employees
- Email, age, and department validations
- Live edit and update using Blazor forms
- Integrated EF Core with real database
- Fully working CRUD API
- Connected frontend using HttpClient
- Stored in SQL Server via EF Core migrations

## 🧪 To Run This Project

1. Clone the repo:
   ```bash
   git clone https://github.com/satyaki24/DOTNET.Blazor_API.git
2. Open Blazor_API.sln in Visual Studio
3. Set Project.API and Project.UI as startup projects
4. Run EF Core setup (optional if DB already created):
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
5. Future Improvements
   - Pagination and sorting
   - Dashboard with summary stats
   - Profile image upload
   - Authentication & role-based access
