﻿// <auto-generated />
using System;
using FinalMockIdentityXCountry.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalMockIdentityXCountry.Migrations
{
    [DbContext(typeof(XCountryDbContext))]
    [Migration("20221023013425_removed-duplicate-columns-from-tables")]
    partial class removedduplicatecolumnsfromtables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("HasBeenSignedOut")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.Property<string>("RunnerId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PracticeId");

                    b.HasIndex("RunnerId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.MessageBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoachId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MessageBody")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MessageTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PublishedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("MessageBoards");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.MessageBoardResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MessageBoardId")
                        .HasColumnType("int");

                    b.Property<string>("ResponderId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ResponseDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MessageBoardId");

                    b.HasIndex("ResponderId");

                    b.ToTable("MessageBoardResponses");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.Practice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoachId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("PracticeEndTimeAndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("PracticeIsInProgress")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PracticeLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PracticeStartTimeAndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("WorkoutsAddedToPractice")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Practices");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.ReplyToMessageBoardResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MessageBoardResponseId")
                        .HasColumnType("int");

                    b.Property<string>("Reply")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ReplyDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReplyerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MessageBoardResponseId");

                    b.HasIndex("ReplyerId");

                    b.ToTable("RepliesToMessageBoardResponse");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.WorkoutInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Distance")
                        .HasColumnType("double");

                    b.Property<double>("Pace")
                        .HasColumnType("double");

                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.Property<string>("RunnerId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("WorkoutTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PracticeId");

                    b.HasIndex("RunnerId");

                    b.HasIndex("WorkoutTypeId");

                    b.ToTable("WorkoutInformation");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.WorkoutType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("WorkoutTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            WorkoutName = "N/A"
                        },
                        new
                        {
                            Id = 2,
                            WorkoutName = "100-meters"
                        },
                        new
                        {
                            Id = 3,
                            WorkoutName = "200-meters"
                        },
                        new
                        {
                            Id = 4,
                            WorkoutName = "400-meters"
                        },
                        new
                        {
                            Id = 5,
                            WorkoutName = "800-meters"
                        },
                        new
                        {
                            Id = 6,
                            WorkoutName = "1600-meters"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.Attendance", b =>
                {
                    b.HasOne("FinalMockIdentityXCountry.Models.Practice", "Practice")
                        .WithMany()
                        .HasForeignKey("PracticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalMockIdentityXCountry.Models.ApplicationUser", "Runner")
                        .WithMany()
                        .HasForeignKey("RunnerId");

                    b.Navigation("Practice");

                    b.Navigation("Runner");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.MessageBoard", b =>
                {
                    b.HasOne("FinalMockIdentityXCountry.Models.ApplicationUser", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.MessageBoardResponse", b =>
                {
                    b.HasOne("FinalMockIdentityXCountry.Models.MessageBoard", "MessageBoard")
                        .WithMany()
                        .HasForeignKey("MessageBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalMockIdentityXCountry.Models.ApplicationUser", "Responder")
                        .WithMany()
                        .HasForeignKey("ResponderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageBoard");

                    b.Navigation("Responder");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.Practice", b =>
                {
                    b.HasOne("FinalMockIdentityXCountry.Models.ApplicationUser", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.ReplyToMessageBoardResponse", b =>
                {
                    b.HasOne("FinalMockIdentityXCountry.Models.MessageBoardResponse", "MessageBoardResponse")
                        .WithMany()
                        .HasForeignKey("MessageBoardResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalMockIdentityXCountry.Models.ApplicationUser", "Replyer")
                        .WithMany()
                        .HasForeignKey("ReplyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageBoardResponse");

                    b.Navigation("Replyer");
                });

            modelBuilder.Entity("FinalMockIdentityXCountry.Models.WorkoutInformation", b =>
                {
                    b.HasOne("FinalMockIdentityXCountry.Models.Practice", "Practice")
                        .WithMany()
                        .HasForeignKey("PracticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalMockIdentityXCountry.Models.ApplicationUser", "Runner")
                        .WithMany()
                        .HasForeignKey("RunnerId");

                    b.HasOne("FinalMockIdentityXCountry.Models.WorkoutType", "WorkoutType")
                        .WithMany()
                        .HasForeignKey("WorkoutTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Practice");

                    b.Navigation("Runner");

                    b.Navigation("WorkoutType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
