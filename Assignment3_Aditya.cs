using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment3_Aditya
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calc Program");
            bool processing = false;
            do
            {
                Console.WriteLine("Press 1 to continue and 2 to Stop");
                string ch = Console.ReadLine();
                if (ch == "1")
                {
                    Calculator();
                    processing = true;
                }
                else if (ch == "2")
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    processing = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    processing = false;
                }
            }while (processing);
        }

        private static void Calculator()
        {
            Console.Write("Enter the first value : ");
            double val1= double.Parse(Console.ReadLine());
            Console.Write("Enter the second value : ");
            double val2 = double.Parse(Console.ReadLine());
            Console.Write("Enter the Operands as + or - or * or / : ");
            string operand=Console.ReadLine();
            switch (operand)
            {

                case "+":
                    Console.WriteLine($"Result: {val1} + {val2} = {val1 + val2}");
                    break;
                case "-":
                    Console.WriteLine($"Result: {val1} - {val2} = {val1 - val2}");
                    break;
                case "*":
                    Console.WriteLine($"Result: {val1} * {val2} = {val1 * val2}");
                    break;
                case "/":
                    if (val2 != 0)
                    {
                        Console.WriteLine($"Result: {val1} / {val2} = {val1 / val2}");
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
