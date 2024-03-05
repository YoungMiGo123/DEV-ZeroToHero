namespace ZeroToHero.DI.Console.Services.CustomerService;
using System;

// Implementation of IDataAccess using Entity Framework for database access
public class DatabaseAccess : IDataAccess
{
    public void SaveData(string data)
    {
        // Code to save data to a database using Entity Framework
        Console.WriteLine($"[Database Access] Saving data: {data}");
    }
}
