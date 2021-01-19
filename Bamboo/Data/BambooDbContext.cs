using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bamboo.Data
{
    public class BambooDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public BambooDbContext(DbContextOptions<BambooDbContext> options) : base(options)
        {
        }
    }
}
