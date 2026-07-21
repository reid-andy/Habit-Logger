using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Logger.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeasurementUnit { get; set; }
    }
}
