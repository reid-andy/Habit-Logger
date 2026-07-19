using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Habit_Logger.Services
{
    public static class DatabaseService
    {
        private static readonly string DataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "data");
        private static readonly string DatabasePath = Path.Combine(DataDirectory, "HabitLogger.db");
        private static readonly string ConnectionString = $"Data Source={DatabasePath}";
        public static string GetConnectionString() => ConnectionString;

        public static void InitializeDatabase()
        {
            try
            {
                if (!Directory.Exists(DataDirectory))
                {
                    Directory.CreateDirectory(DataDirectory);
                }

                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "PRAGMA foreign_keys = ON;";
                        command.ExecuteNonQuery();
                    }
                    CreateHabitsTable(connection);
                    CreateLoggedHabitsTable(connection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
                throw;
            }
        }

        private static void CreateHabitsTable(SqliteConnection connection)
        {
            const string createTableSql = @"
                CREATE TABLE IF NOT EXISTS Habits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name VARCHAR(100) NOT NULL,
                    MeasurementUnit VARCHAR(100) NOT NULL
                );";

            using (var command = connection.CreateCommand())
            {
                command.CommandText = createTableSql;
                command.ExecuteNonQuery();
            }
        }

        private static void CreateLoggedHabitsTable(SqliteConnection connection)
        {
            const string createTableSql = @"
                CREATE TABLE IF NOT EXISTS LoggedHabits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    HabitId INTEGER NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Date TEXT NOT NULL,
                    FOREIGN KEY (HabitId) REFERENCES Habits(Id)
                );";

            using (var command = connection.CreateCommand())
            {
                command.CommandText = createTableSql;
                command.ExecuteNonQuery();
            }
        }
    }
}
