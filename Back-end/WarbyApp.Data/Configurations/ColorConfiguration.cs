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
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(x => x.ColorName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.ColorImage).IsRequired().HasMaxLength(200);
        }
    }
}
