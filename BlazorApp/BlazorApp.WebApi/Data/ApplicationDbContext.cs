using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp.WebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
