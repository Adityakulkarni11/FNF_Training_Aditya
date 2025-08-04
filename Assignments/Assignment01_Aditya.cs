namespace Assignments
{
    /*
     * Assignment 1
     * Write a program that displays the range of all the floating and integral types of.NET CTS
     */

    internal class Assignment01_Aditya
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"The minimum value of byte is {byte.MinValue} and maximum value is {byte.MaxValue}");
            Console.WriteLine($"The minimum value of short is {short.MinValue} and maximum value is {short.MaxValue}");
            Console.WriteLine($"The minimum value of int is {int.MinValue} and maximum value is {int.MaxValue}");
            Console.WriteLine($"The minimum value of long is {long.MinValue} and maximum value is {long.MaxValue}");
            Console.WriteLine($"The minimum value of double is {double.MinValue} and maximum value is {double.MaxValue}");
            Console.WriteLine($"The minimum value of float is {float.MinValue} and maximum value is {float.MaxValue}");

        }
    }
}
