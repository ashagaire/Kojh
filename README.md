# Kojh
A company profile directory web application built in React TypeScript for the frontend and C# for the backend.
Allows users to search and view detailed profiles of registered companies, featuring a responsive user interface built with React and company data managed via RESTful APIs using C# with PostgreSQL.

## DB

- PostgreSQL 
- Connection string: "DefaultConnection"
  - User Secrets:
    - Add { ConnectionStrings: { DefaultConnection: "Server=127.0.0.1;Port=5432;Userid=<YOUR USERID>;Password=<YOUR PSW>;Database=<YOUR DB>;" }} to secrets.json
-Apply the Migration (Update the Database)
  - Menu - Tools > NuGet Package Manager > Package Manager Console
    - Make sure Default project:  Kojh.DAL StartupProject backend
    - `Add-Migration InitialCreate`
    - `Update-Database `

## Figma

- Layout: https://www.figma.com/design/SZABlxWr1cHvmJDLRhRTg6/Kojh?node-id=1-2&t=QN8ZoJw53jF92UXp-0
- Model: https://www.figma.com/board/5ujNV3JVxyB1zMvFR9m5bZ/Kojh?node-id=0-1&p=f&t=JKOuaGvH6XFsmLXR-0

## Libraries

- Entity Framework Core: https://learn.microsoft.com/en-us/ef/core/
- Ardalis Endpoints: https://apiendpoints.ardalis.com/

# Project Setup

1. Clone the repository:
   
   - `git clone <repository-url>`

2. Restore dependencies:

    - `dotnet restore`

3. Build the solution:

    - `dotnet build`

4. Run the application:

    - `dotnet run`


