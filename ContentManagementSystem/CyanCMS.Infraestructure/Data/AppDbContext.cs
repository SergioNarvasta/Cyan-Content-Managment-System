
using CyanCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CMS.Infraestructure.Data
{
	public class AppDbContext : DbContext
	{
		public readonly string connectionString;

		public AppDbContext(DbContextOptions<AppDbContext> options)
		   : base(options)
		{
			
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString);
		}

		public DbSet<User> User { get; set; }
		public DbSet<Company> Company { get; set; }
	}
}
