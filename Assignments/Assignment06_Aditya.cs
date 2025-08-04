using System;
using System.Collections;

namespace Assignments
{
    internal class Assignment06_Aditya
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Year : ");
            int Year=int.Parse(Console.ReadLine());
            Console.Write("Enter the Month : ");
            int Month = int.Parse(Console.ReadLine());
            Console.Write("Enter the Date : ");
            int Date = int.Parse(Console.ReadLine());
            if (isValidDate(Year, Month, Date))
            {
                Console.WriteLine($"The entered date {Year}-{Month}-{Date} is valid");
            }
            else
            {
                Console.WriteLine($"The entered date {Year}-{Month}-{Date} is Invalid");
            }
        }
        static bool isValidDate(int year, int month, int day)
        {
            Hashtable table = new Hashtable();
            table.Add(1, 31);
            table.Add(2, 28);
            table.Add(3, 31);
            table.Add(4, 30);
            table.Add(5, 31);
            table.Add(6, 30);
            table.Add(7, 31);
            table.Add(8, 31);
            table.Add(9, 30);
            table.Add(10, 31);
            table.Add(11, 30);
            table.Add(12, 31);
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                table[2] = 29;
            }
            if (month <= 12 && month >= 1 && day <= (int)table[month] && day >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
