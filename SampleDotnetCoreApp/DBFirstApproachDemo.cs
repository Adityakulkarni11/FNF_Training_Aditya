using SampleDotnetCoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDotnetCoreApp
{
    internal class DBFirstApproachDemo
    {
        static void Main(string[] args)
        {
            //InsertExample();
            //UpdateExample();
            //DeleteExample();
            //GetAllEmployees();
        }

        private static void GetAllEmployees()
        {
            try
            {
                var context = new FnftrainingContext();
                var employees = context.Employees.ToList();
                foreach (var emp in employees)
                {
                    Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, Address: {emp.EmpAddress}, Salary: {emp.EmpSalary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void DeleteExample()
        {
            try
            {
                var context = new FnftrainingContext();
                Console.Write("Enter the Id of Employee to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var employee = context.Employees.FirstOrDefault(e => e.EmpId == id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("Employee deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void UpdateExample()
        {
            try
            {
                var context = new FnftrainingContext();
                var employee = context.Employees.FirstOrDefault(e => e.EmpId == 2);
                if (employee != null)
                {
                    employee.EmpSalary = 65000; 
                    context.SaveChanges();
                    Console.WriteLine("Employee updated Successfully");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void InsertExample()
        {
            try
            {
                var context = new FnftrainingContext();
                context.Employees.Add(new Employee
                {
                    DeptId = 2,
                    EmpName = "John Doe",
                    EmpAddress = "King Landing",
                    EmpSalary = 60000
                });
                context.SaveChanges();
                Console.WriteLine("Employee added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
