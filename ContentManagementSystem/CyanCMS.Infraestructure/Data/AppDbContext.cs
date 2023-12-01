
using CyanCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CMS.Infraestructure.Data
{
	public class AppDbContext : DbContext
	{
        /*
         
         Add-Migration -Context Infraestructure.Data.AppDbContext -name init_01 -verbose
         Update-Database -Verbose -Context AppDbContext
         
         Remove-Migration -Context AppDbContext

        */
        public AppDbContext(DbContextOptions<AppDbContext> options)
		   : base(options)
		{
			
		}

		public DbSet<User> User { get; set; }
		public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
