using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Logger.Services
{
    public static class DateService
    {
        public static string ParseUserDate(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return null;

            if (DateTime.TryParseExact(userInput, "MM-dd-yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out var parsedDate))
            {
                return parsedDate.ToString("yyyy-MM-dd");
            }

            return null;
        }

        public static string FormatForDisplay(string dbDate)
        {
            if (DateTime.TryParse(dbDate, out var date))
            {
                return date.ToString("MM-dd-yyyy");
            }

            return dbDate;
        }

        public static bool IsValidDate(string userInput)
        {
            return DateTime.TryParseExact(userInput, "MM-dd-yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
        }
    }
}
