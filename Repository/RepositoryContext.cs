﻿using Repository.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class RepositoryContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        DbSet<PaymentMethod> PaymentMethods { get; set; }

        DbSet<Bill> Bills { get; set; }

        DbSet<BillProduct> BillProducts { get; set; }

        DbSet<OtpCode> OtpCodes {get; set;}
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
        }

    }
}
