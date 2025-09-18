using DotnetFrameworkLib.Entities;
using DotnetFrameworkLib.Utils;
using DotnetFrameworkLib.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetFrameworkLib.Services

{
    public interface ILaptopService
    {
        List<Laptops> GetAllLaptops();
        Laptops GetLaptop(int id);
        Laptops GetLaptopByEmpname(string empname);
        void AddLaptop(Laptops laptop);
        void UpdateLaptop(Laptops laptop);
        void RemoveLaptop(int id);

    }
    public class LaptopService : ILaptopService
    {
        private readonly string _connectionString;
        private const string STRGETALL = "SELECT * FROM LaptopList";
        private const string STRGETBYEMPNAME = "SELECT * FROM LaptopList Where EmpName = @EmpName";
        private const string INSERTLAPTOP = "INSERT INTO LaptopList (BrandName, ModelName, Price, SerialNumber, EmpName) VALUES (@BrandName, @ModelName, @Price, @SerialNumber, @EmpName)";
        private const string UPDATELAPTOP = "UPDATE LaptopList SET BrandName = @BrandName, ModelName = @ModelName, Price = @Price, SerialNumber = @SerialNumber, EmpName = @EmpName WHERE ID = @ID";
        private const string DELETELAPTOP = "DELETE FROM LaptopList WHERE ID = @ID";

        private EventLog eventlog = new EventLog("Application", Process.GetCurrentProcess().MachineName, "fnfTraining");
        public LaptopService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LaptopDB"].ConnectionString;
        }

        public void AddLaptop(Laptops laptop)
        {
            try
            {
                DatabaseConnector.ExecuteNonQuery(_connectionString, INSERTLAPTOP,
                    new System.Data.SqlClient.SqlParameter("@BrandName", laptop.BrandName),
                    new System.Data.SqlClient.SqlParameter("@ModelName", laptop.ModelName),
                    new System.Data.SqlClient.SqlParameter("@Price", laptop.Price),
                    new System.Data.SqlClient.SqlParameter("@SerialNumber", laptop.SerialNumber),
                    new System.Data.SqlClient.SqlParameter("@EmpName", laptop.EmpName));
            }
            catch (Exception e)
            {
                eventlog.WriteEntry(e.Message, EventLogEntryType.Error);
            }
        }

        public List<Laptops> GetAllLaptops()
        {
            try
            {
                DataTable table = DatabaseConnector.ExecuteQuery(_connectionString, STRGETALL);
                var laptops = new List<Laptops>();

                foreach (DataRow row in table.Rows)
                {
                    // Skip rows with NULL values
                    if (row.IsNull("Id")) continue;

                    laptops.Add(new Laptops
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        BrandName = row["BrandName"].ToString(),
                        ModelName = row["ModelName"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        SerialNumber = row["SerialNumber"].ToString(),
                        EmpName = row["EmpName"].ToString()
                    });
                }

                return laptops;
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetAllLaptops: " + e.Message, e);
                //return new List<Laptops>();
            }
        }





        public Laptops GetLaptop(int id)
        {
            try
            {
                DatabaseConnector.ExecuteNonQuery(_connectionString, STRGETBYEMPNAME,
                    new System.Data.SqlClient.SqlParameter("@EmpName", id));
                return new Laptops();
            }
            catch (Exception e)
            {
                //eventlog.WriteEntry(e.Message, EventLogEntryType.Error);
                return new Laptops();
            }
        }

        public void RemoveLaptop(int id)
        {
            try
            {
                DatabaseConnector.ExecuteQuery(_connectionString, DELETELAPTOP,
                    new System.Data.SqlClient.SqlParameter("@ID", id));
            }
            catch (Exception e)
            {
                //eventlog.WriteEntry(e.Message, EventLogEntryType.Error);
            }
        }

        public Laptops GetLaptopByEmpname(string empname)
        {
            try
            {
                DataTable table=DatabaseConnector.ExecuteQuery(_connectionString, STRGETBYEMPNAME,
                    new System.Data.SqlClient.SqlParameter("@EmpName", empname));
                var laptop= new Laptops();
                laptop.Id= Convert.ToInt32(table.Rows[0]["ID"]);
                laptop.BrandName= table.Rows[0]["BrandName"].ToString();
                laptop.ModelName= table.Rows[0]["ModelName"].ToString();
                laptop.Price= Convert.ToDecimal(table.Rows[0]["Price"]);
                laptop.SerialNumber= table.Rows[0]["SerialNumber"].ToString();
                laptop.EmpName= table.Rows[0]["EmpName"].ToString();
                return laptop;
            }
            catch (Exception e)
            {
                //eventlog.WriteEntry(e.Message, EventLogEntryType.Error);
                return new Laptops();
            }
        }
        public void UpdateLaptop(Laptops laptop)
        {
            try
            {
                DatabaseConnector.ExecuteNonQuery(_connectionString, UPDATELAPTOP,
                    new System.Data.SqlClient.SqlParameter("@ID", laptop.Id),
                    new System.Data.SqlClient.SqlParameter("@BrandName", laptop.BrandName),
                    new System.Data.SqlClient.SqlParameter("@ModelName", laptop.ModelName),
                    new System.Data.SqlClient.SqlParameter("@Price", laptop.Price),
                    new System.Data.SqlClient.SqlParameter("@SerialNumber", laptop.SerialNumber),
                    new System.Data.SqlClient.SqlParameter("@EmpName", laptop.EmpName));

            }
            catch (Exception e)
            {
                //eventlog.WriteEntry(e.Message, EventLogEntryType.Error);
            }
        }  
    }
    public class DisconnectedComponent : ILaptopService
    {
        private readonly DataSet ds;

        private readonly string connString;
        public DisconnectedComponent()
        {
            ds = new DataSet();
            connString = ConfigurationManager.ConnectionStrings["LaptopDB"].ConnectionString;
            var sqlSelect = "SELECT * FROM LaptopList";
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connString))
            {
                adapter.Fill(ds, "FirstTable");
            }
            Logger.LogInformation("Data Stored in FirstTable in memory");
            Logger.LogInformation($"Total Rows : {ds.Tables["FirstTable"].Rows.Count}");
        }

        public List<Laptops> GetAllLaptops()
        {
            List<Laptops> laptops = new List<Laptops>();
            if (ds == null || ds.Tables["FirstTable"] == null)
            {
                Logger.LogInformation("DataSet or FirstTable is null. No data to retrieve.");
                return laptops;
            }

            foreach (DataRow row in ds.Tables["FirstTable"].Rows)
            {
                laptops.Add(new Laptops
                {
                    Id = Convert.ToInt32(row["Id"]),
                    BrandName = row["BrandName"].ToString(),
                    ModelName = row["ModelName"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    SerialNumber = row["SerialNumber"].ToString(),
                    EmpName = row["EmpName"].ToString()
                });
            }

            return laptops;
        }

        public Laptops GetLaptop(int id)
        {
            var row = ds.Tables["FirstTable"].Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => Convert.ToInt32(r["Id"]) == id);

            if (row == null) return null;

            return new Laptops
            {
                Id = Convert.ToInt32(row["Id"]),
                BrandName = row["BrandName"].ToString(),
                ModelName = row["ModelName"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                SerialNumber = row["SerialNumber"].ToString(),
                EmpName = row["EmpName"].ToString()
            };
        }

        public Laptops GetLaptopByEmpname(string empname)
        {
            var row = ds.Tables["FirstTable"].Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => r["EmpName"].ToString().Equals(empname, StringComparison.OrdinalIgnoreCase));

            if (row == null) return null;

            return new Laptops
            {
                Id = Convert.ToInt32(row["Id"]),
                BrandName = row["BrandName"].ToString(),
                ModelName = row["ModelName"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                SerialNumber = row["SerialNumber"].ToString(),
                EmpName = row["EmpName"].ToString()

            };
        }

        public void AddLaptop(Laptops laptop)
        {
            DataRow newRow = ds.Tables["FirstTable"].NewRow();
            newRow["Id"] = laptop.Id;
            newRow["BrandName"] = laptop.BrandName;
            newRow["ModelName"] = laptop.ModelName;
            newRow["Price"] = laptop.Price;
            newRow["SerialNumber"] = laptop.SerialNumber;
            newRow["EmpName"] = laptop.EmpName;
            ds.Tables["FirstTable"].Rows.Add(newRow);
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM LaptopList", connString))
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "FirstTable");
            }
            Logger.LogInformation($"Laptop added: {laptop.BrandName} - {laptop.ModelName}");
        }

        public void UpdateLaptop(Laptops laptop)
        {
            var row = ds.Tables["FirstTable"].Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => Convert.ToInt32(r["Id"]) == laptop.Id);

            if (row != null)
            {
                row["BrandName"] = laptop.BrandName;
                row["ModelName"] = laptop.ModelName;
                row["Price"] = laptop.Price;
                row["SerialNumber"] = laptop.SerialNumber;
                row["EmpName"] = laptop.EmpName;
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM LaptopList", connString))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "FirstTable");
                }
                Logger.LogInformation($"Laptop updated: ID {laptop.Id}");
            }
            else
            {
                Logger.LogInformation($"Laptop with ID {laptop.Id} not found for update.");
            }
        }

        public void RemoveLaptop(int id)
        {
            var row = ds.Tables["FirstTable"].Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => Convert.ToInt32(r["Id"]) == id);

            if (row != null)
            {
                row.Delete(); // Correct way to mark for deletion

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM LaptopList", connString))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds, "FirstTable"); // This will now execute DELETE
                }

                Logger.LogInformation($"Laptop removed: ID {id}");
            }
            else
            {
                Logger.LogInformation($"Laptop with ID {id} not found for removal.");
            }
        }

    }

}
