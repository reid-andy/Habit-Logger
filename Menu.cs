using Habit_Logger.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit_Logger
{
    public static class Menu
    {
        public static string? DisplayMenu(string title, Dictionary<string, string> options)
        {
            Console.Clear();
            Console.WriteLine($"\n---------- {title} ----------");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}: {option.Value}");
            }
            Console.WriteLine($"\n Q: Quit\n");
            Console.Write("Select an option: ");

            string? input = Console.ReadLine()?.ToUpper();

            if (input == "Q")
                return null;

            if (options.ContainsKey(input ?? ""))
                return input;

            Console.WriteLine("Invalid option. Press ENTER to try again.");
            Console.ReadLine();
            return DisplayMenu(title, options);
        }

        public static bool Confirm(string message)
        {
            Console.Write($"\n{message} (Y/N): ");
            string? input = Console.ReadLine()?.ToUpper();
            return input == "Y";
        }

        public static string? GetInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty. Try again.");
            }
        }

        public static int GetNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        public static string GetDate(string prompt)
        {
            while (true)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string? input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input) && DateService.IsValidDate(input))
                        return DateService.ParseUserDate(input)!;

                    Console.WriteLine("Invalid date. Use MM-DD-YYYY format");
                }
            }
        }
    }
}
