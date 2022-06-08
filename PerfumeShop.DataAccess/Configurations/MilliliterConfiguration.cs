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
    public class MilliliterConfiguration : IEntityTypeConfiguration<Milliliter>
    {
        public void Configure(EntityTypeBuilder<Milliliter> builder)
        {
            builder.Property(x => x.Capacity).IsRequired();


            builder.HasMany(x => x.PerfumeMilliliters)
                   .WithOne(x => x.Milliliter)
                   .HasForeignKey(x => x.MilliliterId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
