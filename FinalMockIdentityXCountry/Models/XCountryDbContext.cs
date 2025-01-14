﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalMockIdentityXCountry.Models
{
    public class XCountryDbContext : IdentityDbContext
    {
        public XCountryDbContext(DbContextOptions<XCountryDbContext> options) : base(options) { }

        public DbSet<Attendance> Attendances { get; set; }
        //public DbSet<Coach> Coaches { get; set; }
        public DbSet<MessageBoard> MessageBoards { get; set; }
        public DbSet<MessageBoardResponse> MessageBoardResponses { get; set; }
        public DbSet<Practice> Practices { get; set; }
        //public DbSet<Runner> Runners { get; set; }
        public DbSet<WorkoutInformation> WorkoutInformation { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers{ get; set; }
        public DbSet<ReplyToMessageBoardResponse> RepliesToMessageBoardResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Coach>().HasData(
            //    new Coach { FirstName = "Usain", LastName = "Bolt", Id = 1 },
            //    new Coach { FirstName = "Jesse", LastName = "Owens", Id = 2 },
            //    new Coach { FirstName = "Tom", LastName = "Doe", Id = 3 }
            //    );

            //modelBuilder.Entity<Runner>().HasData(
            //    new Runner { FirstName = "Tiger", LastName = "Woods", Id = 1 },
            //    new Runner { FirstName = "Tom", LastName = "Brady", Id = 2 },
            //    new Runner { FirstName = "Michael", LastName = "Jordan", Id = 3 },
            //    new Runner { FirstName = "Lebron", LastName = "James", Id = 4 },
            //    new Runner { FirstName = "Stephen", LastName = "Curry", Id = 5 }
            //    );

            modelBuilder.Entity<WorkoutType>().HasData(
                 new WorkoutType { WorkoutName = "Easy Miles", Id = 1 },
                new WorkoutType { WorkoutName = "Tempo Run", Id = 2 },
                new WorkoutType { WorkoutName = "Long Run", Id = 3 },
                new WorkoutType { WorkoutName = "Progression Run", Id = 4 },
                new WorkoutType { WorkoutName = "Interval Run", Id = 5 },
                new WorkoutType { WorkoutName = "Track Work", Id = 6 }
                );
        }

        //public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    SeedRoles(roleManager);
        //    SeedUsers(userManager);
        //}

        //public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        //{
        //    if (!roleManager.RoleExistsAsync("Master Admin").Result)
        //    {
        //        IdentityRole role = new IdentityRole();
        //        role.Name = "Master Admin";
        //        IdentityResult roleResult = roleManager.
        //        CreateAsync(role).Result;
        //    }

        //}

        //public static void SeedUsers(UserManager<IdentityUser> userManager)
        //{
        //    if (userManager.FindByNameAsync("Master Admin").Result == null)
        //    {
        //        IdentityUser user = new IdentityUser()
        //        {
        //            UserName = "Master Admin",
        //            Email = "admin@africa.email.com",
        //            NormalizedUserName = "MASTER ADMIN"
        //        };
        //        IdentityResult result = userManager.CreateAsync
        //        (user, "Sesame").Result;

        //        if (result.Succeeded)
        //        {
        //            userManager.AddToRoleAsync(user, "Master Admin").Wait(); 
        //        }
        //    }
        //}

        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Master Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Master Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            //if (!roleManager.RoleExistsAsync("Student").Result)
            //{
            //    IdentityRole role = new IdentityRole();
            //    role.Name = "Student";
            //    IdentityResult roleResult = roleManager.
            //    CreateAsync(role).Result;
            //}
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    //FirstName = "AdminFN",
                    //LastName = "AdminLN",
                    NormalizedUserName = "ADMIN"
                };
                IdentityResult result = userManager.CreateAsync
                (user, "Admin*123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Master Admin").Wait();
                }
            }
        }
    }

}

