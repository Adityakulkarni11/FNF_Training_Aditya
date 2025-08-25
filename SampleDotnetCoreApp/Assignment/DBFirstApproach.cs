using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class DBFirstApproach
    {
        static void Main(string[] args)
        {
            //insertExample();
            //updateExample();
            //deleteExample();
            //getAllExample();
        }

        private static void getAllExample()
        {
            try
            {
                var context = new FnftrainingContext();
                var expenses = context.Expenses.ToList();
                foreach(var exp in expenses)
                {
                    Console.WriteLine($"ID: {exp.ExpenseId}, Description: {exp.ExpDesc}, Amount: {exp.Amount}, Date: {exp.ExpDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void deleteExample()
        {
            try
            {
                var context = new FnftrainingContext();
                Console.Write("Enter the Expense Id to Delete: ");
                int id = int.Parse(Console.ReadLine());
                var rec = context.Expenses.FirstOrDefault(e => e.ExpenseId == id);
                if (rec != null)
                {
                    context.Expenses.Remove(rec);
                    context.SaveChanges();
                    Console.WriteLine("Expense Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("No Record found to delete");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        

        private static void updateExample()
        {
            try
            {
                var context = new FnftrainingContext();
                Console.Write("Enter the Expense Id to Update: ");
                int id=int.Parse(Console.ReadLine());
                var rec = context.Expenses.FirstOrDefault(e => e.ExpenseId == id);
                if (rec != null)
                {
                    Console.WriteLine("Enter new details: ExpDesc, Amount, ExpDate");
                    rec.ExpDesc = Console.ReadLine();
                    rec.Amount = decimal.Parse(Console.ReadLine());
                    rec.ExpDate = DateOnly.FromDateTime(DateTime.Parse(Console.ReadLine()));
                    context.SaveChanges();
                    Console.WriteLine("Expense Updated Successfully");
                }
                else
                {
                    Console.WriteLine("No Record found to update");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void insertExample()
        {
            try
            {
                var context = new FnftrainingContext();
                context.Expenses.Add(new Expense
                {
                    ExpDesc = "Food",
                    Amount = 100,
                    ExpDate = DateOnly.FromDateTime(DateTime.Now) 
                });
                context.SaveChanges();
                Console.WriteLine("Expense Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
