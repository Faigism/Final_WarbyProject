using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class WarbyAppDbContext:IdentityDbContext
    {
        public WarbyAppDbContext(DbContextOptions<WarbyAppDbContext> options):base(options) { }
        public DbSet<Eyeglasses> Eyeglasses { get; set; }
        public DbSet<Sunglasses> Sunglasses { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<EyeglassesColor> EyeglassesColors { get; set; }
        public DbSet<SunglassesColor> SunglassesColors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EyeglassesCategory> EyeglassesCategories { get; set; }
        public DbSet<SunglassesCategory> SunglassesCategories { get; set; }
        public DbSet<CategoryName> CategoryNames { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EyeglassesConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EyeglassesColor>()
                .HasKey(x => new { x.EyeglassesId, x.ColorId });
            modelBuilder.Entity<SunglassesColor>()
                .HasKey(x => new { x.SunglassesId, x.ColorId });
            modelBuilder.Entity<EyeglassesCategory>()
                .HasKey(x => new { x.EyeglassesId, x.CategoryId });
            modelBuilder.Entity<SunglassesCategory>()
                .HasKey(x => new { x.SunglassesId, x.CategoryId });
        }
    }
}
