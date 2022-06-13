using Microsoft.EntityFrameworkCore;
using PerfumeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.DataAccess
{
    public class PerfumeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAZIC\SQLEXPRESS;Initial Catalog=PerfumeShop;Integrated Security=True")
                          .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfumeProductType>().HasKey(x => new { x.PerfumeId, x.ProductTypeId });
            modelBuilder.Entity<PerfumeMilliliter>().HasKey(x => new { x.PerfumeId, x.MilliliterId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });


            modelBuilder.Entity<Perfume>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Brand>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Milliliter>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Image>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ProductType>().HasQueryFilter(x => !x.IsDeleted);


            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            e.IsActive = true;
                            e.IsDeleted = false;
                            break;

                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PerfumeProductType> PerfumeProductTypes { get; set; }
        public DbSet<Milliliter> Milliliters { get; set; }
        public DbSet<PerfumeMilliliter> PerfumeMilliliters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

    }
}
