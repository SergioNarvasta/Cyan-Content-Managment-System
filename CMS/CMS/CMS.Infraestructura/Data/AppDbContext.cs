using CMS.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace CMS.Infraestructura.Data
{
	public class AppDbContext : DbContext
	{
		public readonly string connectionString;

		public AppDbContext(DbContextOptions<AppDbContext> options)
		   : base(options)
		{
			connectionString = "";
				//configuration.GetConnectionString("DefaultConnection");
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString);
		}

		public DbSet<User> User { get; set; }
		public DbSet<Company> Company { get; set; }
	}
}
