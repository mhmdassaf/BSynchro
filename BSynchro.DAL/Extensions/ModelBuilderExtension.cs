using BSynchro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.DAL.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer
                {
                    BirthDate = new DateTime(1995,3,14),
                    City = "Kafrdenis",
                    CreatedBy = "Seed_Function",
                    CreatedDate = DateTime.Now,
                    Email = "mhmd.assaf24@gmail.com",
                    FirstName = "Mohammad",
                    LastName = "Assaf",
                    Gender = 1,
                    JobDescription = "Write clean testable c# code",
                    JobTitle = ".Net Developer",
                    Phone = "+96171355291",
                    State = "Bekaa",
                    Street = "Main Road"
                },
                new Customer
                {
                    BirthDate = new DateTime(1991,6,14),
                    City = "Al Rafed",
                    CreatedBy = "Seed_Function",
                    CreatedDate = DateTime.Now,
                    Email = "sara.assaf@gmail.com",
                    FirstName = "Sara",
                    LastName = "Assaf",
                    Gender = 2,
                    JobDescription = "Sales Manager",
                    JobTitle = "Sales Manager",
                    Phone = "+96170375191",
                    State = "Bekaa",
                    Street = "Main Road"
                },
                new Customer
                {
                    BirthDate = new DateTime(2000,3,6),
                    City = "Bierut",
                    CreatedBy = "Seed_Function",
                    CreatedDate = DateTime.Now,
                    Email = "ahmad.kadri@gmail.com",
                    FirstName = "Ahmad",
                    LastName = "AlKadri",
                    Gender = 1,
                    JobDescription = "Write clean testable c# code",
                    JobTitle = "Fullter Developer",
                    Phone = "+9613355792",
                    State = "Bierut",
                    Street = "Main Road"
                }
            });
        }
    }
}
