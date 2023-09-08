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
    public class CategoryNameConfiguration : IEntityTypeConfiguration<CategoryName>
    {
        public void Configure(EntityTypeBuilder<CategoryName> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ImageName).IsRequired(false).HasMaxLength(200);
        }
    }
}
