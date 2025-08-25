using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class DBFailureException : Exception
    {
        public DBFailureException()
        {

        }
        public DBFailureException(string message) : base(message)
        {

        }
        public DBFailureException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
        internal class Ex14ExceptionHandling
        {
            static void Main(string[] args)
            {
                //TryCatchExample();
                /*
                Retry:
                    try
                    {
                        ThrowKeywordExample();
                    }
                    catch (UnauthorizedAccessException ex) { 
                        Console.WriteLine(ex.Message);
                    }
                */
                try
                {
                    CustomExceptionExample();
                }
                catch (DBFailureException ex)
                {
                    Console.WriteLine($"Custom Exception Caught:{ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception Caught:{ex.Message}");
                }
                finally
                {
                    Console.WriteLine("The execution completed successfully");
                }

            }

            private static void CustomExceptionExample()
            {
                bool isConnected = true;
                Console.WriteLine("Code to connect DB");
                isConnected = false;
                if (!isConnected)
                {
                    throw new DBFailureException("The connection to DB failed");
                }
            }

            private static void ThrowKeywordExample()
            {
                Console.WriteLine("Enter the Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Password : ");
                string pwd = Console.ReadLine();
                if (pwd == "admin" && name == "admin")
                {
                    Console.WriteLine("Successfully Logged In");
                }
                else
                {
                    throw new UnauthorizedAccessException("Invalid username or password");
                }
            }

            private static void TryCatchExample()
            {
            Retry:
                try
                {
                    Console.WriteLine("Enter the age : ");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine($"The age is : {age}");
                    Console.WriteLine("Enter the num1 : ");
                    int num1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the num2 : ");
                    int num2 = int.Parse(Console.ReadLine());
                    long a = num1 / num2;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The System generate message is : {ex.Message}");
                    Console.WriteLine("Enter the valid age no.");
                    goto Retry;
                }
                catch (OverflowException ex1)
                {
                    Console.WriteLine($"The System generate message is : {ex1.Message}");
                    Console.WriteLine($"Input value must be within {int.MinValue} and  {int.MaxValue}");
                    goto Retry;
                }
                catch (ArgumentException ex2)
                {
                    Console.WriteLine($"The System generate message is : {ex2.Message}");
                    goto Retry;
                }
                catch (Exception ex3)
                {
                    Console.WriteLine($"The System generate message is : {ex3.Message}");
                    Console.WriteLine("Divide by Zero is not possible");
                }
                finally
                {
                    Console.WriteLine("The finally block is always executes It is always used to clean the resources,close files or perform any run operation");
                }
            }
        }
}
