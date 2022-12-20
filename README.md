## About this solution

This is a minimalist, non-layered startup solution with the ABP Framework.

## How to run

The application needs to connect to a database. In this case the application is using a SQLite datbase, if you need to use other type of database change the connection string in the appsettings.json file

Run the following command in the `TaskList.App` directory:

````bash
dotnet run --migrate-database
````

This will create and seed the initial database. Then you can run the application with any IDE that supports .NET.

Happy coding..!

