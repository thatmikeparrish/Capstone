using System;
using System.Collections.Generic;
using System.Text;
using capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientType> ClientType { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<EmployeeTypePayRate> EmployeeTypePayRate { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<TimeTracker> TimeTracker { get; set; }
        public DbSet<Total> Total { get; set; }
        public DbSet<WorkforceCalc> WorkforceCalc { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Mike",
                LastName = "Parrish",
                UserName = "thatmikeparrish@gmail.com",
                NormalizedUserName = "THATMIKEPARRISH@GMAIL.COM",
                Email = "thatmikeparrish@gmail.com",
                NormalizedEmail = "THATMIKEPARRISH@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "E@gle6!5");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            Project ProjectOne = new Project
            {
                ProjectId = 1,
                UserId = user.Id,
                ClientId = 1,
                ProjectNumber = "17001",
                SalesTax = .0975,
                UnburdenedRate = 10,
                LaborMargin = .1,
                TotalId = 1,
                WorkforceCalcId = 1,
                CompletionDate = DateTime.Parse("2017-11-15"),
                IsCompleted = true,
                TimeTrackerId = 1
            };

            Project ProjectTwo = new Project
            {
                ProjectId = 2,
                UserId = user.Id,
                ClientId = 2,
                ProjectNumber = "17002",
                SalesTax = .0975,
                UnburdenedRate = 20,
                LaborMargin = .2,
                TotalId = 2,
                WorkforceCalcId = 2,
                IsCompleted = true,
                TimeTrackerId = 2
            };

            modelBuilder.Entity<Project>().HasData(ProjectOne, ProjectTwo);


            modelBuilder.Entity<ClientType>().HasData(
                new ClientType()
                {
                    ClientTypeId = 1,
                    Category = "Personal"
                },
                new ClientType()
                {
                    ClientTypeId = 2,
                    Category = "Commercial"
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    ClientId = 1,
                    ClientTypeId = 1,
                    CompanyName = "Test Company 1",
                    FirstName = "Kayla",
                    LastName = "Carter",
                    Email = "Random@gmail.com",
                    PhoneNumber = "6156491437",
                    StreetAddress = "307 Valley Forge Ct.",
                    City = "LaVergne",
                    State = "TN",
                    ZipCode = "37086",
                    Comments = "My first test project!"
                },

                new Client()
                {
                    ClientId = 2,
                    ClientTypeId = 2,
                    CompanyName = "Test Company 2",
                    FirstName = "Mike",
                    LastName = "Parrish",
                    Email = "thatmikeparrish@gmail.com",
                    PhoneNumber = "6157886484",
                    StreetAddress = "2324 Chandler Pl.",
                    City = "Murfreesboro",
                    State = "TN",
                    ZipCode = "37130",
                    Comments = "My second test project!"
                }
            );

            modelBuilder.Entity<LineItem>().HasData(
                new LineItem()
                {
                    LineItemId = 1,
                    ProjectId = 1,
                    Description = "Build out a 50000 page",
                    MaterialCost = 50000,
                    SubCost = 50000,
                    ManHours = 2
                },

                new LineItem()
                {
                    LineItemId = 2,
                    ProjectId = 2,
                    Description = "Build out a 20000 page",
                    MaterialCost = 20000,
                    SubCost = 20000,
                    ManHours = 4
                },

                new LineItem()
                {
                    LineItemId = 3,
                    ProjectId = 1,
                    Description = "Build out a 5000 page",
                    MaterialCost = 5000,
                    SubCost = 5000,
                    ManHours = 6
                },

                new LineItem()
                {
                    LineItemId = 4,
                    ProjectId = 2,
                    Description = "Build out a 1000 page",
                    MaterialCost = 1000,
                    SubCost = 1000,
                    ManHours = 6
                },

                new LineItem()
                {
                    LineItemId = 5,
                    ProjectId = 1,
                    Description = "Build out a 500 page",
                    MaterialCost = 500,
                    SubCost = 500,
                    ManHours = 6
                },

                new LineItem()
                {
                    LineItemId = 6,
                    ProjectId = 2,
                    Description = "Build out a 100 page",
                    MaterialCost = 100,
                    SubCost = 100,
                    ManHours = 6
                },

                new LineItem()
                {
                    LineItemId = 7,
                    ProjectId = 1,
                    Description = "Build out a free page",
                    MaterialCost = 0,
                    SubCost = 0,
                    ManHours = 6
                }
            );

            modelBuilder.Entity<EmployeeType>().HasData(
                new EmployeeType()
                {
                    EmployeeTypeId = 1,
                    Category = "Lead Developer"
                }, 
                new EmployeeType()
                {
                    EmployeeTypeId = 2,
                    Category = "Senior Developer"
                },
                new EmployeeType()
                {
                    EmployeeTypeId = 3,
                    Category = "Junior Developer"
                }
            );

            modelBuilder.Entity<EmployeeTypePayRate>().HasData(
                new EmployeeTypePayRate()
                {
                    EmployeeTypePayRateId = 1,
                    EmployeeTypeId = 2,
                    UnburdenedPayRate = 15,
                    EmployeeQuantity = 1
                },

                new EmployeeTypePayRate()
                {
                    EmployeeTypePayRateId = 2,
                    EmployeeTypeId = 3,
                    UnburdenedPayRate = 12.50,
                    EmployeeQuantity = 1
                }
            );

            modelBuilder.Entity<WorkforceCalc>().HasData(
                new WorkforceCalc()
                {
                    WorkforceCalcId = 1,
                    EmployeePayRateId = 1
                },

                new WorkforceCalc()
                {
                    WorkforceCalcId = 2,
                    EmployeePayRateId = 2
                }
            );

            modelBuilder.Entity<TimeTracker>().HasData(
                new TimeTracker()
                {
                    TimeTrackerId = 1,
                    UserId = user.Id,
                    Date = DateTime.Parse("2017-11-08"),
                    Hours = 2,
                    Comments = "This went as expected."
                },

                new TimeTracker()
                {
                    TimeTrackerId = 2,
                    UserId = user.Id,
                    Date = DateTime.Parse("2017-11-09"),
                    Hours = 6,
                    Comments = "I had an issue with Grunt."
                }
            );
        }
    }
}
