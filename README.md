# Event Planner App 📅

Welcome to Event Planner App, a web server application developed using Blazor .NET full stack and SQL Server. This app helps users plan and manage events efficiently.

## Prerequisites

Before you begin working on the project, make sure you have the following packages installed:

- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Relational**
- **Microsoft.EntityFrameworkCore.Tools**
- **Microsoft.AspNetCore.Authentication.JwtBearer**
- **Newtonsoft.Json**
- **Microsoft.AspNetCore.OpenApi**
- **Microsoft.EntityFrameworkCore.Proxies**

You can install these packages using the Package Manager Console with the following commands:

## Packages

- **Install-Package Microsoft.EntityFrameworkCore**
- **Install-Package Microsoft.EntityFrameworkCore.SqlServer**
- **Install-Package Microsoft.EntityFrameworkCore.Relational**
- **Install-Package Microsoft.EntityFrameworkCore.Tools**
- **Install-Package Microsoft.AspNetCore.Authentication.JwtBearer**
- **Install-Package Newtonsoft.Json**

Additionally, ensure that you have the necessary environment set up for Blazor .NET development and SQL Server. 

## Database Migration
After installing the required packages, run the following command in the Package Manager Console:
- ## Update-Database

Make sure to set the Default Project to 'EventPlanner' before executing this command.

This command will apply any pending migrations to the database, ensuring that your database schema is up-to-date with the latest changes.

## Running the Application
Once you have installed the packages and migrated the database, you can run the application by building and launching it using your preferred development environment for Blazor .NET projects.
