using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;

namespace WarbyApp.Data.Configurations
{
    public class EyeglassesConfiguration : IEntityTypeConfiguration<Eyeglasses>
    {
        public void Configure(EntityTypeBuilder<Eyeglasses> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Material).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CostPrice).HasColumnType("money");
            builder.Property(x => x.SalePrice).HasColumnType("money");
            builder.Property(x => x.Description1).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Description2).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.DiscountPercent).HasColumnType("decimal(5,2)");
            builder.Property(x => x.ImageName).IsRequired().HasMaxLength(200);
            builder
                .HasMany(c => c.Colors)
                .WithOne(e => e.Eyeglasses)
                .HasForeignKey(ei => ei.EyeglassesId);
        }
    }
}
