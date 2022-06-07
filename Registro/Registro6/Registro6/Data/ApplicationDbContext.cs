using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Registro6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=HDWSDES01;Database=BDEsp;Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
        public DbSet<Registro6.Models.OrdenCompraImp> OrdenCompraImp { get; set; }
    }
}