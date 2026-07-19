using Habit_Logger.Services;
using Microsoft.Data.Sqlite;
using System;

class Program
{

    static void Main()
    {
        DatabaseService.InitializeDatabase();

    }
}