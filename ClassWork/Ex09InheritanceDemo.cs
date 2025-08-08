using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class BaseClass//The class is Internal meaning it cannot be accessed from other assembly/project and if u want to then make it public.
    {
        public void Display()
        {
            Console.WriteLine("This is Base Class");
        }
    }
    //A DC that inherits from BC is required if U want to add functionality or override functionality of the BC. A class is immutable by default meaning you cannot change its functiuonality but inherit from it(OCP)
    //C# does not support multiple inheritance at the same level.But multilevel inheritance is possible.
    class DerivedClass:BaseClass { 
        public void Show()
        {
            Console.WriteLine("Show method is implemented");
        }
    }
    class Ex09InheritanceDemo
    {
        static void Main(string[] args)
        {
            DerivedClass obj= new DerivedClass();
            obj.Show();
            obj.Display();
        }
    }
}
