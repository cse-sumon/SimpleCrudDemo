using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id=1,
                    Name="Male"
                },
                new Gender
                {
                    Id = 2,
                    Name = "Female"
                },
                new Gender
                {
                    Id = 3,
                    Name = "Other"
                }
                );

            modelBuilder.Entity<ProductStatus>().HasData(
                new ProductStatus
                {
                    Id = 1, 
                    Name = "In Stock"
                },
                new ProductStatus
                {
                    Id = 2,
                    Name = "Out of Stock"
                }
                );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
    }
}
