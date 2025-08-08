//Similar to Function pointers of C++. They are used to pass functions are arguments to other Functions. Example could be predicates that are passed for filtering a collection. The Predicate shall provide a logic on how to filter the collection.
//In C#, callbacks and predicates are implementing using delegate. 
//A Delegate is a signature of a method that can be used to call inside another function. 
//Delegate is more like a function type. 
//Delegates are type-safe and secure, meaning they can only call methods that match their signature.

namespace SampleConApp
{
    delegate double MathOp(double a, double b);
    internal class Ex17DelegatesAndEvents
    {
        static void InvokeFunc(Func<double, double, double> func)
        {
            double v1 = ConsoleUtil.GetInputDouble("Enter First value");
            double v2 = ConsoleUtil.GetInputDouble("Enter Second value");
            double result = func(v1, v2);
            Console.WriteLine("The result : " + result);
        }
        static void InvokeMethod(MathOp func)
        {
            double v1 = ConsoleUtil.GetInputDouble("Enter First value");
            double v2 = ConsoleUtil.GetInputDouble("Enter Second value");
            double result = func(v1, v2);
            Console.WriteLine("The result : " + result);
        }
        static void Main(string[] args)
        {
            /////////Old syntax for using the delegate object//////////
            MathOp obj = new MathOp(add);
            //InvokeMethod(obj);

            /////////New syntax for using the delegate object//////////
            //InvokeMethod(add);//Passing the method as a delegate directly
            //InvokeMethod(someFun);
            InvokeFunc(test);
        }
        static double test(double a, double b) => a + b;
        static double add(double a, double b) => a + b;
        static double someFun(double v1, double v2) => v1 * (v2);
    }
}
