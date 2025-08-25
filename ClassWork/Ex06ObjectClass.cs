using System;

namespace SampleConApp
{
    internal class Ex06ObjectClass
    {
        static void Main(string[] args)
        {
            object obj = 10;//Implicit-Boxing
            Console.WriteLine(obj.GetType().Name);
            obj = "Aditya";
            Console.WriteLine(obj.GetType().Name);
            obj = 12398.5558f;
            Console.WriteLine(obj.GetType().Name);
            //int i = (int)obj;
            float f = (float)obj;//Explicit-Unboxing
            Console.WriteLine(obj.GetType());
        }
    }
}
