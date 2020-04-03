﻿// <auto-generated />
using System;
using MP.Author.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MP.Author.Infrastructure.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200402151435_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Objects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActionName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EnumAction")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsApp")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPage")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Method")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("ParentName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Route")
                        .HasColumnType("varchar(255)");

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
                        .HasColumnType("nvarchar(255)");

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
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("MP.Author.Core.Domain.Entities.Role_Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

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
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("IdentityId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("UsersMP");
                });

            modelBuilder.Entity("MP.Author.Infrastructure.Identity.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MP.Author.Infrastructure.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MP.Author.Infrastructure.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MP.Author.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MP.Author.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("MP.Author.Infrastructure.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MP.Author.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MP.Author.Infrastructure.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
