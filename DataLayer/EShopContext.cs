﻿using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EShopContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShop; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Data Seeding

            modelBuilder.Entity<Roles>().HasData(
                new Roles { ID = 1, RoleName = "User" },
                new Roles { ID = 2, RoleName = "Admin" });

            modelBuilder.Entity<Types>().HasData(
                new Types { ID = 1, TypeName = "GPU" },
                new Types { ID = 2, TypeName = "CPU" },
                new Types { ID = 3, TypeName = "Keyboard" },
                new Types { ID = 4, TypeName = "Mouse" },
                new Types { ID = 5, TypeName = "Cooling" });

            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, ProductName = "GPU1", Price = 1100.75M, ImagePath = "ImagePath1", TypeID = 1 },
                new Product { ID = 2, ProductName = "GPU2", Price = 1234.55M, ImagePath = "ImagePath2", TypeID = 1 },
                new Product { ID = 3, ProductName = "CPU1", Price = 8934.10M, ImagePath = "ImagePath3", TypeID = 2 },
                new Product { ID = 4, ProductName = "CPU2", Price = 9313M, ImagePath = "ImagePath4", TypeID = 2 },
                new Product { ID = 5, ProductName = "Keyboard1", Price = 110.75M, ImagePath = "ImagePath5", TypeID = 3 },
                new Product { ID = 6, ProductName = "Keyboard2", Price = 500M, ImagePath = "ImagePath6", TypeID = 3 },
                new Product { ID = 7, ProductName = "Mouse1", Price = 50M, ImagePath = "ImagePath7", TypeID = 4 },
                new Product { ID = 8, ProductName = "Mouse2", Price = 100M, ImagePath = "ImagePath8", TypeID = 4 },
                new Product { ID = 9, ProductName = "Cooling1", Price = 200M, ImagePath = "ImagePath9", TypeID = 5 },
                new Product { ID = 10, ProductName = "Cooling2", Price = 350.50M, ImagePath = "ImagePath10", TypeID = 5 });

            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, FirstName = "Bodil", LastName = "Bodilsen", Mail = "Bodil@Bodilsen.com", Address = "RandomAdress1", ZipCode = "1000", Phone = "88888888", Username = "Bodil", Password = "Bodil123456", RoleId = 1 },
                new User { ID = 2, FirstName = "Hans", LastName = "Hansen", Mail = "Hans@Hansen.com", Address = "RandomAdress2", ZipCode = "5000", Phone = "44444444", Username = "Hans", Password = "Hans123456", RoleId = 2 });

            modelBuilder.Entity<Cart>().HasData(
                new Cart { ID = 1, ProductId = 2, UserId = 1, Amount = 2 },
                new Cart { ID = 2, ProductId = 2, UserId = 2, Amount = 3 },
                new Cart { ID = 3, ProductId = 5, UserId = 1, Amount = 1 },
                new Cart { ID = 4, ProductId = 7, UserId = 1, Amount = 8 });

            #endregion

        }
    }
}