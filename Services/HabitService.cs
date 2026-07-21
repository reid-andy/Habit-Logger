using Habit_Logger.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Habit_Logger.Services
{
    public class HabitService
    {
        private void ExecuteNonQuery(string sql, Action<SqliteCommand> parameters)
        {
            using var connection = new SqliteConnection(DatabaseService.GetConnectionString());
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = sql;
            parameters(command);
            command.ExecuteNonQuery();
        }

        //ExecuteQuery 

        private void AddHabit(Habit habit)
        {
            string sql = "INSERT INTO Habits (Name, MeasurementUnit) VALUES (@name, @measurementUnit)";
            ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@name", habit.Name);
                command.Parameters.AddWithValue("@measurementUnit", habit.MeasurementUnit);
            });
        }

        private void UpdateHabit(int habitId, Habit habit)
        {
            string sql = $"UPDATE Habits SET Name = @name, MeasurementUnit = @measurementUnit WHERE Id = {habitId}";
            ExecuteNonQuery(sql, command =>
            {
                command.Parameters.AddWithValue("@name", habit.Name);
                command.Parameters.AddWithValue("@measurementUnit", habit.MeasurementUnit);
            });
        }
    }
}
