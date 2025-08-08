using System;


namespace SampleConApp
{
    internal class Ex07TuplesExample
    {
        static void Main(string[] args)
        {
            var ex = ( 69, "Rakesh" );
            Console.WriteLine($"The 1st item in Tuple is {ex.Item1} and 2nd item is {ex.Item2}");
            Console.WriteLine("The data type is "+ex.GetType().Name);

            Console.WriteLine();

            var person = (Name: "Aditya", Age: 22, City: "Bidar");
            Console.WriteLine($"The name is {person.Name} aged {person.Age} and lives in {person.City}");

            var (longit, latit,area) = GetCoordinates(2532.12,253.25,"Bidar");
            Console.WriteLine($"The Cordinates are ({longit},{latit},{area})");
        }
        static (double,double,string) GetCoordinates(double a, double b,string c)
        {
            return (a,b,c);
        }
    }
}
