using System;

namespace Assignments
{
    internal class Assignment2_Aditya
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the array elements : ");
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            EvenOdd(arr);
        }

        private static void EvenOdd(int[] arr)
        {
            Console.Write("Even Numbers : ");
            for (int i = 0; i < arr.Length; i++) { 
                if(arr[i]%2==0 )
                {
                    Console.Write(arr[i]+" ");
                }
            }
            Console.WriteLine();
            Console.Write("Odd Numbers : ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    Console.Write(arr[i]+" ");
                }
            }
        }
    }
}
