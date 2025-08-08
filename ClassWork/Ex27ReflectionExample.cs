using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex27ReflectionExample
    {
        static void Main(string[] args)
        {
            var dllLoc = @"C:\Users\6152784\Desktop\Visual Code\C#Basics\SampleCoreLib\bin\Debug\net8.0\SampleCoreLib.dll";
            var assembly = Assembly.Load(dllLoc);
            if(assembly== null)
            {
                Console.WriteLine("Assembly not found.");
                return;
            }
            Type[] types= assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine(type.Name);
            }
        }
    }
}
