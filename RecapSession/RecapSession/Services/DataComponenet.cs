using DotnetCoreLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreLib.Services
{
    public interface IDataComponent
    {
        List<Laptops> GetAllLaptops();
        Laptops GetLaptopById(int id);
        void AddLaptop(Laptops laptop);
        void UpdateLaptop(Laptops laptop);
        void DeleteLaptop(int id);
    }
    public class ConnectedComponent : IDataComponent
    {
        private readonly string _connectionString;
        private const string GETALLLAPTOPS = "SELECT * FROM Laptops";
        private const string GETLAPTOPBYID = "SELECT * FROM Laptops WHERE Id = @Id";
        private const string ADDLAPTOP = "INSERT INTO Laptops (BrandName, ModelName, Price, SerialNumber, EmpName) VALUES (@BrandName, @ModelName, @Price, @SerialNumber, @EmpName)";
        private const string UPDATELAPTOP = "UPDATE Laptops SET BrandName = @BrandName, ModelName = @ModelName, Price = @Price, SerialNumber = @SerialNumber, EmpName = @EmpName WHERE Id = @Id";
        private const string DELETELAPTOP = "DELETE FROM Laptops WHERE Id = @Id";
        public ConnectedComponent(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddLaptop(Laptops laptop)
        {
            throw new NotImplementedException();
        }

        public void DeleteLaptop(int id)
        {
            throw new NotImplementedException();
        }

        public List<Laptops> GetAllLaptops()
        {
            throw new NotImplementedException();
        }

        public Laptops GetLaptopById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLaptop(Laptops laptop)
        {
            throw new NotImplementedException();
        }
    }
}
