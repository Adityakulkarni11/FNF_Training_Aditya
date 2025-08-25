using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDotnetCoreApp.Data
{
    internal class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public int BookPrice { get; set; }
    }

    class Bookcontext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        private const string DB_SOURCE = "(localdb)\\MSSQLLocalDB";
        private const string DB_NAME = "FNFTraining";
        IConfigurationRoot? Configuration { get; set; }

        
        private void ConfigureServices()
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
            if (conf == null)
            {
                throw new Exception("Configuration is null");
            }
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
//open package manager console
//run "Add-Migration InitialCreate" to create the initial migration
//run "Update-Database" to apply the migration to the database
