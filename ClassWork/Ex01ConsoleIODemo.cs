using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex01ConsoleIODemo
    {
       static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            string name=Console.ReadLine();

            Console.WriteLine("Enter the address");
            string address=Console.ReadLine();

            Console.WriteLine($"The entered name is {name}\nThe entered address is {address}");
        }
    }
}
