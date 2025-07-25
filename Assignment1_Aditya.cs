namespace Assignments
{
    internal class Assignment1_Aditya
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Integral Data Types and their range:");
            Console.WriteLine($"int : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"byte : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"short : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"long : {long.MinValue} to {long.MaxValue}");
            Console.WriteLine($"char : {(int)char.MinValue} to {(int)char.MaxValue}");
            Console.WriteLine();
            Console.WriteLine("Floating Data Types and their range:");
            Console.WriteLine($"float : {float.MinValue} to {float.MaxValue}");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue}");
            Console.WriteLine($"decimal : {decimal.MinValue} to {decimal.MaxValue}");
            
        }
    }
}
