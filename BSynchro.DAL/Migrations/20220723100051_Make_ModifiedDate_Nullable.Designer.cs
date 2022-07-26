﻿// <auto-generated />
using System;
using BSynchro.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSynchro.DAL.Migrations
{
    [DbContext(typeof(BSynchroDBContext))]
    [Migration("20220723100051_Make_ModifiedDate_Nullable")]
    partial class Make_ModifiedDate_Nullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BSynchro.DAL.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ModifedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OpeningBalance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BSynchro.DAL.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModifedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("978cf690-019d-44ae-9c19-c6fd23e3d5cf"),
                            BirthDate = new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Kafrdenis",
                            CreatedBy = "Seed_Function",
                            CreatedDate = new DateTime(2022, 7, 23, 13, 0, 51, 232, DateTimeKind.Local).AddTicks(7774),
                            Email = "mhmd.assaf24@gmail.com",
                            FirstName = "Mohammad",
                            Gender = 1,
                            JobDescription = "Write clean testable c# code",
                            JobTitle = ".Net Developer",
                            LastName = "Assaf",
                            Phone = "+96171355291",
                            State = "Bekaa",
                            Street = "Main Road"
                        },
                        new
                        {
                            Id = new Guid("cf517245-ea5c-4bb6-8bb4-b5a5ec411a58"),
                            BirthDate = new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Al Rafed",
                            CreatedBy = "Seed_Function",
                            CreatedDate = new DateTime(2022, 7, 23, 13, 0, 51, 232, DateTimeKind.Local).AddTicks(7823),
                            Email = "sara.assaf@gmail.com",
                            FirstName = "Sara",
                            Gender = 2,
                            JobDescription = "Sales Manager",
                            JobTitle = "Sales Manager",
                            LastName = "Assaf",
                            Phone = "+96170375191",
                            State = "Bekaa",
                            Street = "Main Road"
                        },
                        new
                        {
                            Id = new Guid("776c813d-03e1-4979-b058-6ab402a58377"),
                            BirthDate = new DateTime(2000, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Bierut",
                            CreatedBy = "Seed_Function",
                            CreatedDate = new DateTime(2022, 7, 23, 13, 0, 51, 232, DateTimeKind.Local).AddTicks(7832),
                            Email = "ahmad.kadri@gmail.com",
                            FirstName = "Ahmad",
                            Gender = 1,
                            JobDescription = "Write clean testable c# code",
                            JobTitle = "Fullter Developer",
                            LastName = "AlKadri",
                            Phone = "+9613355792",
                            State = "Bierut",
                            Street = "Main Road"
                        });
                });

            modelBuilder.Entity("BSynchro.DAL.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FromAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FromCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ToAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("FromCustomerId");

                    b.HasIndex("ToAccountId");

                    b.HasIndex("ToCustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BSynchro.DAL.Entities.Account", b =>
                {
                    b.HasOne("BSynchro.DAL.Entities.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BSynchro.DAL.Entities.Transaction", b =>
                {
                    b.HasOne("BSynchro.DAL.Entities.Account", "FromAccount")
                        .WithMany("FromAccountTransactions")
                        .HasForeignKey("FromAccountId");

                    b.HasOne("BSynchro.DAL.Entities.Customer", "FromCustomer")
                        .WithMany("FromCustomerTransactions")
                        .HasForeignKey("FromCustomerId")
                        .IsRequired();

                    b.HasOne("BSynchro.DAL.Entities.Account", "ToAccount")
                        .WithMany("ToAccountTransactions")
                        .HasForeignKey("ToAccountId");

                    b.HasOne("BSynchro.DAL.Entities.Customer", "ToCustomer")
                        .WithMany("ToCustomerTransactions")
                        .HasForeignKey("ToCustomerId")
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("FromCustomer");

                    b.Navigation("ToAccount");

                    b.Navigation("ToCustomer");
                });

            modelBuilder.Entity("BSynchro.DAL.Entities.Account", b =>
                {
                    b.Navigation("FromAccountTransactions");

                    b.Navigation("ToAccountTransactions");
                });

            modelBuilder.Entity("BSynchro.DAL.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("FromCustomerTransactions");

                    b.Navigation("ToCustomerTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
