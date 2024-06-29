using System;
using Microsoft.EntityFrameworkCore;
using practice_Api.Models;

namespace practice_Api.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Category> Categories { get; set; }




	}
}

