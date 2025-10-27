# Express Voitures

A simple CRUD web application for managing car listings built with ASP.NET Core 9 MVC, Entity Framework Core, and C#.

## Requirements

- [**.NET 9.0 SDK**](https://dotnet.microsoft.com/fr-fr/download/dotnet/9.0)
- **SQL Server**
- **Git**
- An **IDE** of your choice, such as:
    - **Visual Studio 2022**
    - **JetBrains Rider**
    - **Visual Studio Code** ([with the C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit))

## Getting Started

Follow these steps to get a local copy up and running.

### 1. Clone the Repository and Switch to the Dev Branch

Open your terminal, clone the project, and then switch to the `dev` branch.

```
git clone https://github.com/Floverflow11/CarExpress.git
cd CarExpress
git checkout dev
```

### 2. Update database connection string

Edit `appsettings.json` with your database configuration.

### 3. Apply migrations

`dotnet ef database update`

### 4. Run the Application

You can run the project using the command line or directly from your IDE.

#### Using the Command Line

```
dotnet restore
dotnet run
```

#### Using an IDE
1. Open the solution file *CarExpress.sln* in Visual Studio or JetBrains Rider.
2. Press F5 or click the Run button.
3. The IDE will automatically restore dependencies, build, and launch the application.

### 5. Create an account manually

Create an account from the built-in register page, that account comes with administrator privileges by default.