# Deraa
An apartment listing web application built in React Typescript for Frontend and C# for Backend.

## DB

- PostgreSQL
- Connection string: "DefaultConnection"
  - User Secrets:
    - Add { ConnectionStrings: { DefaultConnection: "Server=127.0.0.1;Port=5432;Userid=<YOUR USERID>;Password=<YOUR PSW>;Database=<YOUR DB>;" }} to secrets.json
-Apply the Migration (Update the Database)
  - Menu - Tools > NuGet Package Manager > Package Manager Console
    - Make sure Default project:  Deraa.DAL StartupProject backend
    - `Add-Migration InitialCreate`
    - `Update-Database `

## Figma

- Layout: https://www.figma.com/design/SZABlxWr1cHvmJDLRhRTg6/Deraa?node-id=1-2&t=q1wMLPvsx5RBSWjs-0
- Model: https://www.figma.com/board/5ujNV3JVxyB1zMvFR9m5bZ/Deraa?node-id=0-1&p=f&t=q1wMLPvsx5RBSWjs-0

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


