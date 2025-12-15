# Reactivities: A Step-by-Step Tutorial

This document provides a beginner-friendly, step-by-step guide to building the "Reactivities" application.

## Table of Contents

1.  **Introduction**

    *   **What is Reactivities?**

        "Reactivities" is a social event application that allows users to create, join, and manage events. It's a full-stack application designed to showcase the integration of a .NET back-end with a React front-end.

    *   **Technologies Used**

        *   **.NET 9:** A free, open-source, cross-platform framework for building modern, cloud-based, and internet-connected applications.
        *   **React 19:** A JavaScript library for building user interfaces.
        *   **TypeScript:** A strongly typed programming language that builds on JavaScript, giving you better tooling at any scale.
        *   **Entity Framework Core:** A modern object-database mapper for .NET.
        *   **SQLite:** A C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine.

2.  **Prerequisites**

    *   **Software to Install**

        Before you begin, make sure you have the following software installed on your computer:

        *   **.NET 9 SDK:** [Download and install the .NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
        *   **Node.js (v18+ or v20+):** [Download and install Node.js](https://nodejs.org/en/download/)
        *   **Git:** [Download and install Git](https://git-scm.com/downloads)
        *   **A code editor:** [Visual Studio Code](https://code.visualstudio.com/) is a great option for both .NET and React development.
3.  **Back-End Setup (.NET)**

    *   **Creating the .NET Web API Project**

        1.  **Open your terminal or command prompt.**

        2.  **Create a new directory for your project and navigate into it:**

            ```bash
            mkdir Reactivities
            cd Reactivities
            ```

        3.  **Create a new .NET Web API project:**

            ```bash
            dotnet new webapi -n API
            ```

            This command creates a new project named "API" in a new directory of the same name.

        4.  **Navigate into the API directory:**

            ```bash
            cd API
            ```

        5.  **Open the project in your code editor.** If you're using Visual Studio Code, you can do this by running:

            ```bash
            code .
            ```

    *   **Defining the Domain Model**

        1.  **Create a new class library project for the domain:**

            In the root `Reactivities` directory (the one containing the `API` directory), run the following command:

            ```bash
            dotnet new classlib -n Domain
            ```

        2.  **Add a reference to the `Domain` project from the `API` project:**

            Navigate into the `API` directory and run:

            ```bash
            dotnet add reference ../Domain/Domain.csproj
            ```

        3.  **Create the `Activity` entity:**

            In the `Domain` project, create a new file named `Activity.cs` and add the following code:

            ```csharp
            using System;

            namespace Domain
            {
                public class Activity
                {
                    public Guid Id { get; set; }
                    public string Title { get; set; }
                    public string Description { get; set; }
                    public string Category { get; set; }
                    public DateTime Date { get; set; }
                    public string City { get; set; }
                    public string Venue { get; set; }
                }
            }
            ```

    *   **Setting Up the Database with Entity Framework Core**

        1.  **Create a new class library project for persistence:**

            In the root `Reactivities` directory, run:

            ```bash
            dotnet new classlib -n Persistence
            ```

        2.  **Add a reference to the `Persistence` project from the `API` project:**

            Navigate into the `API` directory and run:

            ```bash
            dotnet add reference ../Persistence/Persistence.csproj
            ```

        3.  **Add Entity Framework Core packages to the `Persistence` project:**

            Navigate into the `Persistence` directory and run these commands:

            ```bash
            dotnet add package Microsoft.EntityFrameworkCore
            dotnet add package Microsoft.EntityFrameworkCore.Sqlite
            ```

        4.  **Define the `DataContext`:**

            In the `Persistence` project, create a new file named `DataContext.cs` and add the following code:

            ```csharp
            using Domain;
            using Microsoft.EntityFrameworkCore;

            namespace Persistence
            {
                public class DataContext : DbContext
                {
                    public DataContext(DbContextOptions options) : base(options)
                    {
                    }

                    public DbSet<Activity> Activities { get; set; }
                }
            }
            ```

        5.  **Configure the database in the `API` project:**

            In the `API` project, open the `Program.cs` file and replace its content with the following:

            ```csharp
            using Microsoft.EntityFrameworkCore;
            using Persistence;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            ```

        6.  **Add the connection string to `appsettings.Development.json`:**

            In the `API` project, open `appsettings.Development.json` and add the following connection string:

            ```json
            {
              "ConnectionStrings": {
                "DefaultConnection": "Data Source=reactivities.db"
              },
              "Logging": {
                "LogLevel": {
                  "Default": "Information",
                  "Microsoft.AspNetCore": "Warning"
                }
              }
            }
            ```

        7.  **Create the initial database migration:**

            In the `API` directory, run the following command. You will need to have the `dotnet-ef` tool installed. If you don't have it, run `dotnet tool install --global dotnet-ef` first.

            ```bash
            dotnet ef migrations add InitialCreate -p ../Persistence -s .
            ```

        8.  **Apply the migration to the database:**

            In the `API` directory, run:

            ```bash
            dotnet ef database update -p ../Persistence -s .
            ```
4.  **Front-End Setup (React)**
    *   Creating the React Application
    *   Connecting the Front-End to the Back-End
    *   Building the User Interface
5.  **Running the Application**
6.  **Conclusion**
