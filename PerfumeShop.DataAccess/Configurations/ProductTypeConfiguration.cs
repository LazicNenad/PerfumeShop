using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.DataAccess.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<PerfumeShop.Domain.Entities.ProductType>
    {
        public void Configure(EntityTypeBuilder<PerfumeShop.Domain.Entities.ProductType> builder)
        {
            builder.Property(x => x.Type).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.Type).IsUnique();

            builder.HasMany(x => x.PerfumeTypes)
                   .WithOne(ppt => ppt.ProductType)
                   .HasForeignKey(ppt => ppt.ProductTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
