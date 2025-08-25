using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data
{
    internal class College
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public int EstablishedYear { get; set; }

        [Required]
        public int NoOfDepartments { get; set; }

    }
    class CollegeContext : DbContext
    {
        public DbSet<College> Colleges { get; set; }
        //private const string DB_SOURCE = "(localdb)\\MSSQLLocalDB";
        //private const string DB_NAME = "FNFTraining";
        IConfigurationRoot? Configuration { get; set; }
        private void ConfigureServices()
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
            Configuration = conf;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ConfigureServices();
            //var connectionString = $"Data Source={DB_SOURCE};Initial Catalog={DB_NAME};Integrated Security=True;TrustServerCertificate=True";
            var connectionString = Configuration["connectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
