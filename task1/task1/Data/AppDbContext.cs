using System;
using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Data
{
    public class AppDbContext : DbContext
    {
        
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

       public DbSet<Country> Countries { get; set; }
      public DbSet<City> Cities { get; set; }

    }
}

