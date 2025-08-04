using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment09_Aditya
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Sentence : ");
            string str=Console.ReadLine();
            Console.WriteLine($"The Reversed Sentence is : {reverseByWords(str)}");
        }

        private static string reverseByWords(string str)
        {
            string[] words = str.Split(' ');
            string reversed = "";
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversed += words[i];
                if (i > 0)
                {
                    reversed += " ";
                }
            }
            return reversed;
        }
    }
}
