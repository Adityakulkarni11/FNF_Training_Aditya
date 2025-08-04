using System;
namespace Assignments
{
    class Assignment07_Aditya
    {
        static bool isPrimeNumber(int num)
        {
            if (num <= 1)
                return false;
            if (num == 2)
                return true;
            if (num % 2 == 0)
                return false;
            for (int i = 3; i <= (int)Math.Floor(Math.Sqrt(num)); i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the number : ");
            int number = int.Parse(Console.ReadLine());
            if (isPrimeNumber(number))
            {
                Console.WriteLine($"The number {number} is prime number");
                return;
            }
            Console.WriteLine($"The number {number} is not a prime number");
            
        }
    }
}
