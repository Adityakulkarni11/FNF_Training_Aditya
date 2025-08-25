
using Assignment.Data;

namespace Assignment
{
    internal class Program
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
                var context = new CollegeContext();
                var colleges = context.Colleges.ToList();
                if (colleges.Count == 0)
                {
                    Console.WriteLine("No Records found");
                    return;
                }
                foreach (var college in colleges)
                {
                    Console.WriteLine($"Id: {college.Id}, Name: {college.Name}, Address: {college.Address}, EstablishedYear: {college.EstablishedYear}, NoOfDepartments: {college.NoOfDepartments}");
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
                var context = new CollegeContext();
                Console.Write("Enter the Id of the College to Delete: ");
                var id = int.Parse(Console.ReadLine());
                var rec = context.Colleges.FirstOrDefault(c => c.Id == id);
                if (rec != null)
                {
                    context.Colleges.Remove(rec);
                    context.SaveChanges();
                    Console.WriteLine("College Deleted Successfully");
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
                var context = new CollegeContext();
                Console.Write("Enter the Id of the College to Update: ");
                var id = int.Parse(Console.ReadLine());
                var rec = context.Colleges.FirstOrDefault(c => c.Id == id);
                if (rec != null)
                {
                    Console.WriteLine("Enter new details: Name, Address, EstablishedYear, NoOfDepartments");
                    rec.Name = Console.ReadLine();
                    rec.Address = Console.ReadLine();
                    rec.EstablishedYear = int.Parse(Console.ReadLine());
                    rec.NoOfDepartments = int.Parse(Console.ReadLine());
                    context.SaveChanges();
                    Console.WriteLine("College Updated Successfully");
                }
                else
                {
                    Console.WriteLine("No Record found to update");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void insertExample()
        {
            try
            {
                var context = new CollegeContext();
                Console.WriteLine("Enter College Details: Name, Address, EstablishedYear, NoOfDepartments");
                var college = new College()
                { 
                    Name = Console.ReadLine(),
                    Address = Console.ReadLine(),
                    EstablishedYear = int.Parse(Console.ReadLine()),
                    NoOfDepartments = int.Parse(Console.ReadLine())
                };
                context.Colleges.Add(college);
                context.SaveChanges();
                Console.WriteLine("New College Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
