using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    Name = "Male"
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
                    Name = "Active"
                },
                new ProductStatus
                {
                    Id = 2,
                    Name = "InActive"
                }
                );

            modelBuilder.Entity<Color>().HasData(
               new Color
               {
                   Id = 1,
                   Name = "White"
               },
               new Color
               {
                   Id = 2,
                   Name = "Red"
               },
                new Color
                {
                    Id = 3,
                    Name = "Blue"
                },
                 new Color
                 {
                     Id = 4,
                     Name = "Green"
                 },
                  new Color
                  {
                      Id = 5,
                      Name = "Black"
                  },
                   new Color
                   {
                       Id = 6,
                       Name = "Yellow"
                   },
                    new Color
                    {
                        Id = 7,
                        Name = "Magenta"

                    }
               );



        }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
