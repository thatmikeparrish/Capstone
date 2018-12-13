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
        public DbSet<ProjectLineItem> ProjectLineItem { get; set; }
        public DbSet<Margin> Margin { get; set; }
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

            modelBuilder.Entity<Project>().HasData(
                new Project()
                {
                    ProjectId = 1,
                    UserId = user.Id,
                    ClientId = 1,
                    ProjectNumber = "17001",
                    MarginsId = 1,
                    TotalId = 1,
                    WorkforceId = 1,
                    CompletionDate = DateTime.Parse("2017-11-15"),
                    IsCompleted = true,
                    TimeTrackerId = 1
                },
                new Project()
                {
                    ProjectId = 2,
                    UserId = user.Id,
                    ClientId = 2,
                    ProjectNumber = "17002",
                    MarginsId = 2,
                    TotalId = 2,
                    WorkforceId = 2,
                    IsCompleted = false,
                    TimeTrackerId = 2
                }
            );

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

            modelBuilder.Entity<Margin>().HasData(
                new Margin()
                {
                    MarginId = 1,
                    UnburdenedRate = 0,
                    Insurance = 0,
                    LaborTotal = 0,
                    Travel = 0,
                    Consumables = 0,
                    Equipment = 0,
                    CompositeLabor = 0,
                },

                new Margin()
                {
                    MarginId = 2,
                    UnburdenedRate = 10,
                    Insurance = 10,
                    LaborTotal = 10,
                    Travel = 10,
                    Consumables = 10,
                    Equipment = 10,
                    CompositeLabor = 10,
                }
            );

            modelBuilder.Entity<LineItem>().HasData(
                new LineItem()
                {
                    LineItemId = 1,
                    Description = "Build out a home page",
                    MaterialCost = 0,
                    SubCost = 0,
                    ManHours = 2
                },

                new LineItem()
                {
                    LineItemId = 2,
                    Description = "Build out a bio page",
                    MaterialCost = 0,
                    SubCost = 0,
                    ManHours = 4
                },

                new LineItem()
                {
                    LineItemId = 3,
                    Description = "Build out a Contact page",
                    MaterialCost = 0,
                    SubCost = 0,
                    ManHours = 6
                }
            );

            modelBuilder.Entity<ProjectLineItem>().HasData(
               new ProjectLineItem()
               {
                   ProjectLineItemId = 1,
                   ProjectId = 1,
                   LineItemId = 1
               },

               new ProjectLineItem()
               {
                   ProjectLineItemId = 2,
                   ProjectId = 2,
                   LineItemId = 2
               },

               new ProjectLineItem()
               {
                   ProjectLineItemId = 3,
                   ProjectId = 2,
                   LineItemId = 3
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
