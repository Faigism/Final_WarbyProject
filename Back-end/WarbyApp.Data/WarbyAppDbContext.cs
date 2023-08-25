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
        public DbSet<ColorImage> ColorImages { get; set; }
        public DbSet<EyeglassesImage> EyeglassesImages { get; set; }
        public DbSet<WidthCategory> WidthCategories { get; set; }
        public DbSet<ShapeCategory> ShapeCategories { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<ColorCategory> ColorCategories { get; set; }
        public DbSet<PriceCategory> PriceCategories { get; set; }
        public DbSet<PrescriptionCategory> PrescriptionCategories { get; set; }
        public DbSet<FeaturesCategory> FeaturesCategories { get; set; }
        public DbSet<BridgeCategory> BridgeCategories { get; set; }
        public DbSet<EyeglassesWidthCategory> EyeglassesWidthCategories { get; set; }
        public DbSet<EyeglassesShapeCategory> EyeglassesShapeCategories { get; set; }
        public DbSet<EyeglassesMaterialCategory> EyeglassesMaterialCategories { get; set; }
        public DbSet<EyeglassesColorCategory> EyeglassesColorCategories { get; set; }
        public DbSet<EyeglassesPriceCategory> EyeglassesPriceCategories { get; set; }
        public DbSet<EyeglassesPrescriptionCategory> EyeglassesPrescriptionCategories { get; set; }
        public DbSet<EyeglassesFeaturesCategory> EyeglassesFeaturesCategories { get; set; }
        public DbSet<EyeglassesBridgeCategory> EyeglassesBridgeCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EyeglassesConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EyeglassesWidthCategory>().HasKey(x => new { x.EyeglassesId, x.WidthCategoryId });
            modelBuilder.Entity<EyeglassesShapeCategory>().HasKey(x => new { x.EyeglassesId, x.ShapeCategoryId });
            modelBuilder.Entity<EyeglassesMaterialCategory>().HasKey(x => new { x.EyeglassesId, x.MaterialCategoryId });
            modelBuilder.Entity<EyeglassesColorCategory>().HasKey(x => new { x.EyeglassesId, x.ColorCategoryId });
            modelBuilder.Entity<EyeglassesPriceCategory>().HasKey(x => new { x.EyeglassesId, x.PriceCategoryId });
            modelBuilder.Entity<EyeglassesPrescriptionCategory>().HasKey(x => new { x.EyeglassesId, x.PrescriptionCategoryId });
            modelBuilder.Entity<EyeglassesFeaturesCategory>().HasKey(x => new { x.EyeglassesId, x.FeaturesCategoryId });
            modelBuilder.Entity<EyeglassesBridgeCategory>().HasKey(x => new { x.EyeglassesId, x.BridgeCategoryId });
        }
    }
}
