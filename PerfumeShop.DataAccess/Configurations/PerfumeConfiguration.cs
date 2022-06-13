using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.DataAccess.Configurations
{
    public class PerfumeConfiguration : IEntityTypeConfiguration<Perfume>
    {
        public void Configure(EntityTypeBuilder<Perfume> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasMany(x => x.PerfumeProductTypes)
                   .WithOne(x => x.Perfume)
                   .HasForeignKey(x => x.PerfumeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PerfumeMilliliters)
                   .WithOne(x => x.Perfume)
                   .HasForeignKey(x => x.PerfumeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderLines)
                .WithOne(x => x.Perfume)
                .HasForeignKey(x => x.PerfumeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
