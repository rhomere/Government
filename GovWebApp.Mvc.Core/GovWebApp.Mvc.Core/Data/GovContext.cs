using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GovWebApp.Mvc.Core.Models;

namespace GovWebApp.Mvc.Core.Data
{
    public class GovContext : DbContext
    {
        public GovContext(DbContextOptions<GovContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Officials> Officials { get; set; }
    }
}
