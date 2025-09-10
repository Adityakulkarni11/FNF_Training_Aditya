using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIWithJWT.Models;

namespace WebAPIWithJWT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}