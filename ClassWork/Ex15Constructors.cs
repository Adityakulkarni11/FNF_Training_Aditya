using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.ConstuctorExample
{
    class SuperClass
    {
        public SuperClass() {
            Console.WriteLine("This is super class constructor");
        }
        public SuperClass(string msg):this() 
        {
            Console.WriteLine($"This is super class constructor with {msg} as parameter");
        }
    }
    class BaseClass: SuperClass
    {
        public BaseClass():base("aditya")
        {
            Console.WriteLine("This is base class constructor");
        }
    }
    class DerivedClass: BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine("This is derived class constructor");
        }
    }
    internal class Ex15Constructors
    {
        static void Main(string[] args)
        {
            //SuperClass sup=new SuperClass();
            //BaseClass bs=new BaseClass();
            DerivedClass dev=new DerivedClass();
        }
    }
}
