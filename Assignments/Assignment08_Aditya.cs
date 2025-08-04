using System;

namespace Assignments
{
    class Assignment08_Aditya
    {
        public static void Main(string[] args)
        {
            int month=ConsoleUtil.GetInputInt("Enter the month (1-12): ");
            int year=ConsoleUtil.GetInputInt("Enter the year (e.g., 2023): ");
            printCalendar(month, year); 
        }

        public static void printCalendar(int month, int year)
        {
            if (month < 1 || month > 12 || year < 1)
            {
                Console.WriteLine("Invalid month or year.");
                return;
            }

            string[] days = { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
            int daysInMonth = GetDaysInMonth(month, year);
            int startDay = GetStartDay(month, year); // 0 = Sunday

            Console.WriteLine($"\nCalendar for {GetMonthName(month)} {year}\n");

            // Print header
            foreach (var day in days)
                Console.Write(day + " ");
            Console.WriteLine();

            // Print initial spaces
            for (int i = 0; i < startDay; i++)
                Console.Write("   ");

            // Print days
            for (int date = 1; date <= daysInMonth; date++)
            {
                Console.Write($"{date,2} ");
                if ((startDay + date) % 7 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
        }

        static int GetDaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 2:
                    return IsLeapYear(year) ? 29 : 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 31;
            }
        }

        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        static string GetMonthName(int month)
        {
            string[] names = { "January", "February", "March", "April", "May", "June",
                               "July", "August", "September", "October", "November", "December" };
            return names[month - 1];
        }

        static int GetStartDay(int month, int year)
        {
            // Zeller's Congruence algorithm
            if (month < 3)
            {
                month += 12;
                year--;
            }

            int q = 1; // Day of month
            int m = month;
            int k = year % 100;
            int j = year / 100;

            int h = (q + (13 * (m + 1)) / 5 + k + (k / 4) + (j / 4) + 5 * j) % 7;

            // Zeller's returns: 0=Saturday, 1=Sunday, ..., 6=Friday
            // Convert to: 0=Sunday, ..., 6=Saturday
            return (h + 6) % 7;

        }
    }
}
