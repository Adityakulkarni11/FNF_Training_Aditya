using System;

namespace Assignments
{
    internal class Assignment04_Aditya
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the data type of the array(int, short, byte, float, long, double) : ");
            string type=Console.ReadLine().ToLower();
            switch(type)
            {
                case "int":IntegerArray(n);break;
                case "short":ShortArray(n); break;
                case "byte":ByteArray(n);break;
                case "float":FloatArray(n); break;
                case "long":LongArray(n);break;
                case "double":DoubleArray(n);break;
                default:
                    Console.WriteLine("Invalid data type");
                    break;
            }
        }
        private static void DoubleArray(int n)
        {
            double[] doubleArray = new double[n];
            Console.WriteLine("Enter the array elements : ");
            for (int i = 0; i < n; i++)
            {
                doubleArray[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("Array Elements are :");
            foreach (var item in doubleArray)
            {
                Console.Write(item + " ");
            }
        }
        private static void LongArray(int n)
        {
            long[] longArray = new long[n];
            Console.WriteLine("Enter the array elements : ");
            for (int i = 0; i < n; i++)
            {
                longArray[i] = long.Parse(Console.ReadLine());
            }
            Console.Write("Array Elements are :");
            foreach (var item in longArray)
            {
                Console.Write(item + " ");
            }
        }
        private static void ByteArray(int n)
        {
            byte[] byteArray = new byte[n];
            Console.WriteLine("Enter the array elements : ");
            for (int i = 0; i < n; i++)
            {
                byteArray[i] = byte.Parse(Console.ReadLine());
            }
            Console.Write("Array Elements are :");
            foreach (var item in byteArray)
            {
                Console.Write(item + " ");
            }
        }
        private static void ShortArray(int n)
        {

            short[] shortArray = new short[n];
            Console.WriteLine("Enter the array elements : ");
            for (int i = 0; i < n; i++)
            {
                shortArray[i] = short.Parse(Console.ReadLine());
            }
            Console.Write("Array Elements are :");
            foreach (var item in shortArray)
            {
                Console.Write(item + " ");
            }

        }
        private static void FloatArray(int n)
        {
            float[] floatArray = new float[n];
            Console.WriteLine("Enter the array elements : ");
            for (int i = 0; i < n; i++)
            {
                floatArray[i] = float.Parse(Console.ReadLine());
            }
            Console.Write("Array Elements are :");
            foreach (var item in floatArray)
            {
                Console.Write(item+" ");
            }
        }
        private static void IntegerArray(int n)
        {

            int[] intArray = new int[n];
            Console.WriteLine("Enter the array elements : ");
            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Array Elements are : ");
            foreach (var item in intArray)
            {
                Console.Write(item+" ");
            }
        }
    }
}
