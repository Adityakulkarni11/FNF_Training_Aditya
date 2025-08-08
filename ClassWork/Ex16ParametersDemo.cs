using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex16ParametersDemo
    {
        public static void NormalPrameter(int x)
        {
            Console.WriteLine("The value of normal parameter is :"+x);
            x = 123;
            Console.WriteLine("The value of normal parameter after modification is :" + x);
        }
        public static void NormalPrameter1(int x) => Console.WriteLine("The value of normal parameter is :" + x);
           
        public static void AddFunc(int a ,int b,out double result)
        {
            result=  a+b;
        }

        public static void ArithmeticFunc(int a, int b,ref double add,ref double sub, ref double multi, ref double div)
        {
            add = a + b;
            sub = a - b;
            multi=a*b;
            if (b != 0)
            {
                div = a / b;
            }
            else
            {
                Console.WriteLine("Divide by Zero is not possible");
            }
        }

        public static long ParamsAddNumbers(params int[] numbers)
        {
            long sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        } 
        static void Main(string[] args)
        {
            //Normal Parameter Example
            int x = 10;
            NormalPrameter(x);
            NormalPrameter1(x);

            //Out Parameter Example
            double result;
            AddFunc(10, 20,out result);
            Console.WriteLine("The result is "+result);

            //Ref Parameter Example
            double add =0,sub=0,multi=0,div = 0;
            ArithmeticFunc(20,0,ref add,ref sub,ref multi,ref div);
            Console.WriteLine($"Add = {add}, Sub = {sub}, Multi = {multi}, Div = {div}");

            //Params Parameter Example
            long res=ParamsAddNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            Console.WriteLine("The result is "+res);
        }
    }
}
