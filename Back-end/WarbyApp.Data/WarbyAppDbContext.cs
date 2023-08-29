using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;
using WarbyApp.Data.Configurations;

namespace WarbyApp.Data
{
    public class WarbyAppDbContext:DbContext
    {
        public WarbyAppDbContext(DbContextOptions<WarbyAppDbContext> options):base(options) { }
        public DbSet<Eyeglasses> Eyeglasses { get; set; }
        public DbSet<Sunglasses> Sunglasses { get; set; }
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<ContactLens> ContactLens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EyeglassesConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
