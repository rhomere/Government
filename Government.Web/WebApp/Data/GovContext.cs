using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class GovContext : DbContext
    {
        public GovContext(DbContextOptions<GovContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<WebApp.Models.Official> Official { get; set; }
    }
}
