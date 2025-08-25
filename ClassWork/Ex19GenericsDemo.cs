using System;
using System.Collections.Generic;//This is the namespace for Generics.
using SampleConApp.GenericsEx;
//Generics is a feature of .NET that can allow to create classes, methods and interfaces that can work on any kind of data type. They are similar to templates in C++. They are said to be type-safe, meaning that they can enforce type constraints at compile time, reducing runtime errors. U dont have to unbox the data when U use generics, as they are already type-safe.
namespace SampleConApp.GenericsEx
{

    internal class Ex19GenericsDemo
    {
        static void Main(string[] args)
        {
            //listExample();
            //HashSetExample();
            DictionaryExample();

        }
        //Similar to hashtable, but it is type-safe and does not require boxing and unboxing. It is a collection of key-value pairs, where each key is unique and maps to a value. Does not allow duplicate keys, but allows duplicate values.
        private static void DictionaryExample()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("John", "app123");
            users.Add("Jane", "test123");
            users.Add("Doe", "pass123");
            users.Add("Alice", "alice123");
            users["Jenny"]= "jenny123"; //This will add a new key-value pair or update the value if the key already exists.
            var name=ConsoleUtil.GetInputString("Enter a name to login: ");
            var password = ConsoleUtil.GetInputString("Enter a password to login: ");
            if (users.ContainsKey(name) && users[name]==password)
            {
                Console.WriteLine("Login Successfull");
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
        }

        //HasSet is a collection that contains no duplicate elements and has no defined ordering. It is implemented using a hash table, which allows for fast lookups, additions, and deletions. HashSet is also a generic collection, meaning that it can store any type of data.
        private static void HashSetExample()
        {
            //SimpleHashSetExample();   
            EmployeeHashSetExample();
        }

        private static void EmployeeHashSetExample()
        {
            HashSet<Employee> employees = new HashSet<Employee>();
            employees.Add(new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" });
            employees.Add(new Employee { EmpID = 2, EmpName = "Jane", EmpAddress = "Los Angeles", EmpSalary = 60000, Designation = "Developer" });
            employees.Add(new Employee { EmpID = 3, EmpName = "Doe", EmpAddress = "Chicago", EmpSalary = 55000, Designation = "Designer" });
            employees.Add(new Employee { EmpID = 4, EmpName = "Alice", EmpAddress = "Houston", EmpSalary = 70000, Designation = "Tester" });
            employees.Add(new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" });
            employees.Add(new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" });

            Console.WriteLine($"The total number of employees is {employees.Count}");//Output will be 4, as HashSet does not allow duplicate items.
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"{emp.EmpName} earns a salary of {emp.EmpSalary:C}");
            }
        }

        private static void SimpleHashSetExample()
        {
            HashSet<string> hs = new HashSet<string>();
            hs.Add("John");
            hs.Add("Jane");
            hs.Add("Doe");
            hs.Add("Doe");
            hs.Add("Bob");
            hs.Add("Bob");
            Console.WriteLine($"The tota meambers in the team is {hs.Count()}");//Output will be 4, as HashSet does not allow duplicate items.

            foreach (var names in hs)
            {
                Console.WriteLine(names);//Iterating through the HashSet using foreach loop. It is similar to List, but it does not allow duplicate items.
            }
            HashSet<int> hs1 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs1.Add(4);
            hs1.Add(5);
            foreach (var number in hs1)
            {
                Console.WriteLine(number);
            }
        }

        //List is a generic collection that can store a list of items of any type. It is similar to an array, but it can grow and shrink dynamically as items are added or removed. List is also a generic collection, meaning that it can store any type of data. It is implemented using an array internally, which allows for fast access to items by index.
        private static void listExample()
        {
            List<string> names = new List<string>();
            names.Add("John");//Add only strings to the list.
            names.Add("Jane");
            names.Add("Doe");
            names.Add("Smith");
            names.Add("Alice");
            names.Add("Bob");
            names.Insert(2, "Charlie");//Insert at index 2. This will shift the other items to the right.

            //Iterating through the list using foreach loop. foreach is a easy way to iterate through a collection in C#. It is forward-only and readonly. U can move by 1 number at a time.
            foreach (string name in names)
            {
                Console.WriteLine(name);//No unboxing is required as the list is of type string.
            }
            //Like ArrayList, here also U can insert, remove, and search for items in the list from any where.
            string nameToFind = ConsoleUtil.GetInputString("Enter a name to find: ");
            if (!names.Contains(nameToFind))
            {
                Console.WriteLine("UR Entered Name does not exist");
            }
            else
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i] == nameToFind)
                    {
                        Console.WriteLine($"UR Entered Name is found at index {i}");
                        break; //Exit the loop once the name is found.
                    }
                }
                var index = names.IndexOf(nameToFind); //IndexOf is a method that returns the index of the first occurrence of the specified item in the list.
                Console.WriteLine($"UR Entered Name is found at index {index}");
            }
        }
    }
}
