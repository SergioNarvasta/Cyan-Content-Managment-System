
using CyanCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CyanCMS.Infraestructure.Data
{
	public class AppDbContext : DbContext
	{
        /*
         Seleccionar Proyecto de Inicio -> WebAPI (Instalar EF Design)
         Seleccionar Proyecto Predeterminado en Consola de Adm Paq Nuget -> Infraestructure (Instalar EF Core, Tools, SQLServer)

         Add-Migration -Context CyanCMS.Infraestructure.Data.AppDbContext -name init_01 -Verbose
         Update-Database -Verbose -Context AppDbContext
         
         Remove-Migration -Context AppDbContext

        */
        public AppDbContext(DbContextOptions<AppDbContext> options)
		   : base(options)
		{
			
		}

		public DbSet<User> User { get; set; }
		public DbSet<Company> Company { get; set; }
        public DbSet<Rol> Rol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
