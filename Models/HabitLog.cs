using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Logger.Models
{
    public class HabitLog
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }

        public string? HabitName { get; set; }
        public string? HabitMeasurementUnit { get; set; }
    }
}
