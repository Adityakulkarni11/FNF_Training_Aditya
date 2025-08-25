using System;

namespace SampleConApp
{
    interface IExample
    {
        void ShowExample();
    }
    interface IExample1
    {
        void ShowExample();
    }
    interface ISimple
    {
        void ShowSimple();
    }
    class SimpleExample : IExample, ISimple
    {
        public void ShowExample()
        {
            Console.WriteLine("This is an example of implemeting multiple interface");
        }

        public void ShowSimple()
        {
            Console.WriteLine("This is an Simple example of implemeting multiple interface");

        }
    }
    class ExampleSquare : IExample, IExample1
    {
        public void ShowExample()
        {
            Console.WriteLine("This is an Std example of implemettation of ShowExample");
        }
        void IExample.ShowExample()
        {
            Console.WriteLine("This is an explicit implemetation of ShowExample method of IExample");
        }
        void IExample1.ShowExample()
        {
            Console.WriteLine("This is an explicit implemetation of ShowExample method of IExample1");
        }
    }
    internal class Ex13AdvancedInterfaceCocepts
    {
        static void Main(string[] args)
        {
            IExample obj=new SimpleExample();
            obj.ShowExample();
            ISimple obj1 = new SimpleExample();
            obj1.ShowSimple();


            ExampleSquare obj4 = new ExampleSquare();
            obj4.ShowExample();
            IExample obj2=new ExampleSquare();
            obj2.ShowExample();
            IExample1 obj3 = (IExample1)obj2;
            obj3.ShowExample();
        }
    }
}
