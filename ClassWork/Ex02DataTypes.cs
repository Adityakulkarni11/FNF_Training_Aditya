using System;

namespace SampleConApp
{
    /*
     * All data types in C# are based on Common Type System(CTS) of .NET Framework. 
     * CTS provides a common set of data types for all languages of .NET.
     * They are broadly classified as primitive types(Structs) and reference types(classes). 
     * Primitive types or known types are data types that are common among all languages: They are also called as VALUE TYPES.
     * Integral Types: byte(2 Bit), short(16), int(32), long(64) 
     * Floating Types: float(Single), double(Double), decimal(128Bit)
     * Other Types: Char(2 Bytes), Bool(1 Byte). Tuples.  
     * User Defined Types: Enums, Structs... 
     * Reference types are classes: Arrays, Delegates, Normal Classes that U create and are available in .NET framework. 
     * Value type variables directly store the value in them. Reference types store the location of the value as the value shall be created in the heap managed by the .NET Runtime.
     * Classes are available to convert one type to another. Some types cannot be converted at compile time. 
     * Larger types can hold smaller type values, but its reverse needs explicit or forceful conversions(CASTING).
     * Due to CTS, the data type conversions among the languages of the .NET is possible. All data types of all the programming languages are from CTS only. 
     */
    internal class Ex02DataTypes
    {
        static void Main(string[] args)
        {
            int iVal = 256;
            long lVal = 25688965544;
            float fVal = 2569.23f;
            double dVal = 589654.2358;
            char ch='A';
            bool bVal = false;

            //Console.WriteLine($"The value of iVal is {iVal}\nThe value of lVal is {lVal}\nThe value of fVal is {fVal}\nThe value of dVal is {dVal}\nThe value of ch is {ch}\nThe value of bVal is {bVal}\n");


            //Console.WriteLine("The value of iVal is {0}\nThe value of lVal is {1}\nThe value of fVal is {2}\nThe value of dVal is {3}\nThe value of ch is {4}\nThe value of bVal is {5}\n",iVal,lVal,fVal,dVal,ch,bVal);

            //DisplayUserDetails();

            TypeCastingExample();

        }

        static void DisplayUserDetails()
        {
            Console.WriteLine("Enter the name");
            string name=Console.ReadLine();

            Console.WriteLine("Enter the age");
            int age=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your mobile no.");
            long mobile=long.Parse(Console.ReadLine());

            Console.WriteLine($"Name is {name}\nAge is {age}\nMobile No. is {mobile}");

            Console.WriteLine("Name is {0}\nAge is {1}\nMobile No. is {2}",name,age,mobile);
        }

        static void TypeCastingExample()
        {
            int iVal = 123;
            long lVal = iVal;
            double dVal = 123.5689;
            lVal = (long)dVal;
            //lVal=Convert.ToInt64(dVal);
            Console.WriteLine(lVal);
        }
    }
}
