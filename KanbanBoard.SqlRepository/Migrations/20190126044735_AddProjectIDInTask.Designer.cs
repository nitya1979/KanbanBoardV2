﻿// <auto-generated />
using System;
using KanbanBoard.SqlRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KanbanBoard.SqlRepository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190126044735_AddProjectIDInTask")]
    partial class AddProjectIDInTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbPriority", b =>
                {
                    b.Property<int>("PriorityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasMaxLength(125);

                    b.HasKey("PriorityID");

                    b.ToTable("tblPriority");

                    b.HasData(
                        new { PriorityID = 1, CreateDate = new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), CreatedBy = "system", PriorityName = "Critical" },
                        new { PriorityID = 2, CreateDate = new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), CreatedBy = "system", PriorityName = "Hight" },
                        new { PriorityID = 3, CreateDate = new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), CreatedBy = "system", PriorityName = "Medium" },
                        new { PriorityID = 4, CreateDate = new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), CreatedBy = "system", PriorityName = "Low" }
                    );
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbProject", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CompletionDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("QuadrantID");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ProjectID");

                    b.ToTable("tblProject");
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbProjectStage", b =>
                {
                    b.Property<int>("StageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("Order");

                    b.Property<int>("ProjectID");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("StageID");

                    b.HasIndex("ProjectID");

                    b.ToTable("tblProjectStage");
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbProjectTask", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompletionDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Description")
                        .HasMaxLength(4000);

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<int>("PriorityID");

                    b.Property<int>("PriortyID");

                    b.Property<int>("ProjectID");

                    b.Property<int>("StageID");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TaskID");

                    b.HasIndex("PriortyID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("StageID");

                    b.ToTable("tblProjectTask");
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbQuadrant", b =>
                {
                    b.Property<int>("QuadrantID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("QuadrantName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("QuadrantID");

                    b.ToTable("tblQuadrant");
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.KanbanRoles", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutMe");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbProjectStage", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.DbProject", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KanbanBoard.SqlRepository.DbProjectTask", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.DbPriority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriortyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KanbanBoard.SqlRepository.DbProject", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KanbanBoard.SqlRepository.DbProjectStage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.KanbanRoles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.KanbanRoles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KanbanBoard.SqlRepository.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KanbanBoard.SqlRepository.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
