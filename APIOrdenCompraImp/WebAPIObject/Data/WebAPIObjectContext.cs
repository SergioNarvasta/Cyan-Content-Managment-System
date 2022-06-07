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

        public DbSet<WebAPIObject.Models.Item>? Item { get; set; }
    }
}
