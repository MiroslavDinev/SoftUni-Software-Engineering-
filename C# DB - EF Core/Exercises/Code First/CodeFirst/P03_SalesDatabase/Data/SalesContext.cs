using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ProductEntityCreator(modelBuilder);
            this.CustomerEntityCreator(modelBuilder);
            this.StoreEntityCreator(modelBuilder);
            this.SaleEntityCreator(modelBuilder);
        }

        private void SaleEntityCreator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder.Entity<Sale>()
                .Property(d => d.Date)
                .HasDefaultValueSql("GETDATE()");

        }

        private void StoreEntityCreator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder.Entity<Store>()
                .Property(n => n.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder.Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(st => st.Store);
        }

        private void CustomerEntityCreator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(n => n.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer);
        }

        private void ProductEntityCreator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.ProductId);

            modelBuilder.Entity<Product>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(d => d.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Product>()
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product);
        }
    }
}
