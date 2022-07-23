using BSynchro.DAL.Entities;
using BSynchro.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.DataContext
{
    public class BSynchroDBContext : DbContext
    {
        public BSynchroDBContext(DbContextOptions<BSynchroDBContext> options): base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(p => p.ModifedBy).HasMaxLength(100);
                entity.Property(p => p.CreatedBy).HasMaxLength(100);
                entity.Property(p => p.City).HasMaxLength(20);
                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(p => p.ModifedBy).HasMaxLength(100);
                entity.Property(p => p.CreatedBy).HasMaxLength(100);
                entity.Property(p => p.OpeningBalance).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.Number).IsRequired();
                entity.Property(p => p.Name).IsRequired();

                entity.HasOne(p => p.Customer)
                      .WithMany(c => c.Accounts)
                      .HasForeignKey(p => p.CustomerId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(p => p.ModifedBy).HasMaxLength(100);
                entity.Property(p => p.CreatedBy).HasMaxLength(100);
                entity.Property(p => p.Amount).IsRequired();

                entity.HasOne(p => p.FromAccount)
                      .WithMany(c => c.FromAccountTransactions)
                      .HasForeignKey(p => p.FromAccountId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.ToAccount)
                    .WithMany(c => c.ToAccountTransactions)
                    .HasForeignKey(p => p.ToAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.FromCustomer)
                    .WithMany(c => c.FromCustomerTransactions)
                    .HasForeignKey(p => p.FromCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.ToCustomer)
                    .WithMany(c => c.ToCustomerTransactions)
                    .HasForeignKey(p => p.ToCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Seed();
        }
    }
}
