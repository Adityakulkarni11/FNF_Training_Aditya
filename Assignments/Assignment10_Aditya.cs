using System;

namespace Assignments
{
    class Assignment10_Aditya
    {
        public static void Main(string[] args)
        {
            int num = ConsoleUtil.GetInputInt("Enter a number between 0 and 999999999: ");
            TestInWords(num);
        }

        public static void TestInWords(int num)
        {
            Console.WriteLine($"{num} => {inWords(num)}");
        }

        public static string inWords(int num)
        {
            if (num == 0) return "zero";
            if (num < 0 || num > 999999999)
                return "Number out of supported range.";

            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty",
                              "sixty", "seventy", "eighty", "ninety" };

            string ConvertTwoDigits(int n)
            {
                if (n < 20)
                    return ones[n];
                else
                    return tens[n / 10] + (n % 10 != 0 ? " " + ones[n % 10] : "");
            }

            string ConvertThreeDigits(int n)
            {
                if (n == 0) return "";
                if (n < 100)
                    return ConvertTwoDigits(n);
                else
                    return ones[n / 100] + " hundred" + (n % 100 != 0 ? " " + ConvertTwoDigits(n % 100) : "");
            }

            string result = "";

            int crore = num / 10000000;
            num %= 10000000;

            int lakh = num / 100000;
            num %= 100000;

            int thousand = num / 1000;
            num %= 1000;

            int hundredAndBelow = num;

            if (crore > 0)
                result += ConvertTwoDigits(crore) + " crore ";
            if (lakh > 0)
                result += ConvertTwoDigits(lakh) + " lakh ";
            if (thousand > 0)
                result += ConvertTwoDigits(thousand) + " thousand ";
            if (hundredAndBelow > 0)
                result += ConvertThreeDigits(hundredAndBelow);

            return result.Trim();
        }
    }
}

