using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIObject.Models;

namespace WebAPIObject.Data
{
    public class WebAPIObjectContext : DbContext
    {
        public WebAPIObjectContext (DbContextOptions<WebAPIObjectContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=HDWSDES01;Database=BD;Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
        public DbSet<WebAPIObject.Models.OrdenCompraImp>? OrdenCompraImp{ get; set; }
        
    }
}
