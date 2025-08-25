using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // For FileInfo and Directory classes

namespace SampleConApp
{
    internal class Ex21FileIOExample
    {
        static void Main(string[] args)
        {
            //displyFileInfo();
            //displayDirInfo();
            //CreatingCSVFile();
            ReadingCSVFile();
        }

        private static void ReadingCSVFile()
        {
            
            var filePath = "C:\\Users\\6152784\\Desktop\\customer.csv";
            if (File.Exists(filePath))
            {
                var content = File.ReadAllText(filePath);
                var parts = content.Split(',');
                if (parts.Length == 3)
                {
                    var customer = new Customer
                    {
                        CustomerId = int.Parse(parts[0]),
                        CustomerName = parts[1],
                        BillAmount = double.Parse(parts[2])
                    };
                    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.CustomerName}, Bill Amount: {customer.BillAmount}");
                }
                else
                {
                    Console.WriteLine("Invalid CSV format.");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        private static void CreatingCSVFile()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                CustomerName = "John Doe",
                BillAmount = 100.50
            };
            var filePath = "C:\\Users\\6152784\\Desktop\\customer.csv";
            var content=$"{customer.CustomerId},{customer.CustomerName},{customer.BillAmount}";
            File.WriteAllText(filePath, content);
        }

        private static void displayDirInfo()
        {
            Console.WriteLine("--------------------------------------------------");
            var directories = Directory.GetDirectories("C:\\Users\\6152784\\Desktop\\Visual Code\\C#Basics");
            foreach (var dir in directories)
            {
                var selectestDir = new DirectoryInfo(dir);
                Console.WriteLine($"Directory Name: {selectestDir.Name}, Created on {selectestDir.CreationTime}");
            }

            Console.WriteLine("--------------------------------------------------");
            var newDirectory = "C:\\TestDir";
            var dirInfo = Directory.CreateDirectory(newDirectory);
            var parent = dirInfo.Parent;
            foreach (var dir_path in directories)
            {
                var dirInfoPath = new DirectoryInfo(dir_path);
                foreach (var file in dirInfoPath.GetFiles())
                {
                    Console.WriteLine($"File Name: {file.Name}");
                }
            }
        }

        private static void displyFileInfo()
        {
            var files = Directory.GetFiles("C:\\Users\\6152784\\Desktop\\Visual Code\\C#Basics\\SampleConApp");
            foreach (var file in files)
            {
                var selectestFile = new FileInfo(file);
                Console.WriteLine($"File Name: {selectestFile.Name}, Created on {selectestFile.CreationTime}");
            }
        }
    }
}
