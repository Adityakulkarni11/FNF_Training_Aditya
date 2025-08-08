using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleConApp
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double BillAmount { get; set; }
    }

    class CustomerCollection : IEnumerable<Customer>
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer) => customers.Add(customer);

        public bool RemoveCustomer(int customerId)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
            {
                customers.Remove(customer);
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer updatedCustomer)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == updatedCustomer.CustomerId);
            if (customer != null)
            {
                customer.CustomerName = updatedCustomer.CustomerName;
                customer.BillAmount = updatedCustomer.BillAmount;
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> SearchByName(string name)
        {
            return customers.Where(c => c.CustomerName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Customer> GetAllCustomers() => customers;

        public void SaveAsCsv(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("CustomerId,CustomerName,BillAmount");
                foreach (var c in customers)
                {
                    writer.WriteLine($"{c.CustomerId},{c.CustomerName},{c.BillAmount}");
                }
            }
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            foreach (var customer in customers)
                yield return customer;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void LoadFromCsv(string filePath)
        {
            if (!File.Exists(filePath)) return;

            using (var reader = new StreamReader(filePath))
            {
                string headerLine = reader.ReadLine(); // Skip header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(',');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[0], out int id) &&
                        double.TryParse(parts[2], out double amount))
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = id,
                            CustomerName = parts[1],
                            BillAmount = amount
                        });
                    }
                }
            }
        }
    }

    internal class Ex20CustomCollections
    {
        static void Main(string[] args)
        {
            CustomerCollection repo = new CustomerCollection();
            var csvPath = "C:\\Users\\6152784\\Desktop\\customer.csv";
            repo.LoadFromCsv(csvPath);

            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~CUSTOMER MANAGEMENT SYSTEM~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("TO ADD NEW CUSTOMER PRESS 1");
                Console.WriteLine("TO REMOVE CUSTOMER PRESS 2");
                Console.WriteLine("TO UPDATE CUSTOMER DETAILS PRESS 3");
                Console.WriteLine("TO DISPLAY ALL CUSTOMERS PRESS 4");
                Console.WriteLine("TO SEARCH FOR A CUSTOMER BY NAME PRESS 5");
                Console.WriteLine("NOTE: PRESS Any TO EXIT");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                

                switch (input)
                {
                    case "1":
                        Console.Write("Enter Customer ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Customer Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Bill Amount: ");
                        double amount = double.Parse(Console.ReadLine());
                        repo.AddCustomer(new Customer { CustomerId = id, CustomerName = name, BillAmount = amount });
                        repo.SaveAsCsv(csvPath);
                        Console.WriteLine($"Customers saved to {csvPath}\n");
                        break;
                    case "2":
                        Console.Write("Enter Customer ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        if (repo.RemoveCustomer(removeId))
                        {
                            Console.WriteLine("Customer removed.\n");
                            repo.SaveAsCsv(csvPath);
                        }
                        else
                            Console.WriteLine("Customer not found.\n");
                        
                        break;
                    case "3":
                        Console.Write("Enter Customer ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Bill Amount: ");
                        double newAmount = double.Parse(Console.ReadLine());
                        if (repo.UpdateCustomer(new Customer { CustomerId = updateId, CustomerName = newName, BillAmount = newAmount }))
                        {
                            repo.SaveAsCsv(csvPath);
                            Console.WriteLine("Customer updated.\n");
                        }
                        else
                            Console.WriteLine("Customer not found.\n");
                        break;
                    case "4":
                        Console.WriteLine("All Customers:");
                        foreach (var cust in repo)
                        {
                            Console.WriteLine($"ID={cust.CustomerId}, Name={cust.CustomerName}, Bill Amount={cust.BillAmount}");
                        }
                        break;
                    case "5":
                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();
                        var found = repo.SearchByName(searchName).ToList();
                        if (found.Count > 0)
                        {
                            foreach (var cust in found)
                                Console.WriteLine($"ID={cust.CustomerId}, Name={cust.CustomerName}, Bill Amount={cust.BillAmount}");
                        }
                        else
                        {
                            Console.WriteLine("No customer found with that name.");
                        }
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Exiting Application.\n");
                        return;
                }
            }
            Console.WriteLine("Exiting application.");
        }
    }
}
