﻿// <auto-generated />
using System;
using MP.Author.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MP.Author.Infrastructure.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.MenuItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Menus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsShow")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Objects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActionName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ControllerName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EnumAction")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsApp")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPage")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Method")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("ParentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Route")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Operations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Create")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Delete")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Edit")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Export")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Import")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("View")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.HasIndex("OperationId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Role_Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<string>("RoleId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("Role_Permission");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IdentityId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Permissions", b =>
                {
                    b.HasOne("MP.Author.Core.Domain.Entities.Objects", "Object")
                        .WithMany("Permissions")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MP.Author.Core.Domain.Entities.Operations", "Operation")
                        .WithMany("Permissions")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("MP.Author.Core.Domain.Entities.User", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Role_Permission", b =>
                {
                    b.HasOne("MP.Author.Core.Domain.Entities.Permissions", "Permission")
                        .WithMany("RolePermission")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
