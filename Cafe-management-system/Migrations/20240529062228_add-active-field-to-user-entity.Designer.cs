﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository;

#nullable disable

namespace Cafe_management_system.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240529062228_add-active-field-to-user-entity")]
    partial class addactivefieldtouserentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Bill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("BillId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreationDate");

                    b.Property<Guid>("guid")
                        .HasColumnType("uuid")
                        .HasColumnName("Guid");

                    b.Property<int>("paymentMethodId")
                        .HasColumnType("integer")
                        .HasColumnName("PaymentMethodId");

                    b.Property<int>("userId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("id");

                    b.HasIndex("paymentMethodId");

                    b.HasIndex("userId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Entities.Models.BillProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("billId")
                        .HasColumnType("integer")
                        .HasColumnName("BillId");

                    b.Property<int>("productId")
                        .HasColumnType("integer")
                        .HasColumnName("ProductId");

                    b.Property<int>("quantity")
                        .HasColumnType("integer")
                        .HasColumnName("Quantity");

                    b.HasKey("id");

                    b.HasIndex("billId");

                    b.HasIndex("productId");

                    b.ToTable("BillProducts");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CategoryId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("CategoryName");

                    b.Property<int>("userId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Models.OtpCode", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("OtpCodeId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("attempsCnt")
                        .HasColumnType("integer")
                        .HasColumnName("AttempsCnt");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("Code");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreationDate");

                    b.Property<bool>("used")
                        .HasColumnType("boolean")
                        .HasColumnName("Used");

                    b.Property<int>("userId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("OtpCodes");
                });

            modelBuilder.Entity("Entities.Models.PaymentMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("PaymentMethodId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "Cash"
                        },
                        new
                        {
                            id = 2,
                            description = "Bank"
                        },
                        new
                        {
                            id = 3,
                            description = "Creadit card"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ProductId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("boolean")
                        .HasColumnName("Active");

                    b.Property<int>("categoryId")
                        .HasColumnType("integer")
                        .HasColumnName("CategoryId");

                    b.Property<string>("description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<float>("price")
                        .HasColumnType("real")
                        .HasColumnName("Price");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("ProductName");

                    b.Property<int>("status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<int>("userId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.HasIndex("userId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("RoleId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("roleId"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Description");

                    b.HasKey("roleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            roleId = 1,
                            description = "Admin"
                        },
                        new
                        {
                            roleId = 2,
                            description = "Manager"
                        },
                        new
                        {
                            roleId = 3,
                            description = "Staff"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userId"));

                    b.Property<bool>("active")
                        .HasColumnType("boolean")
                        .HasColumnName("Active");

                    b.Property<DateTime?>("birthday")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Birthday");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Email");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Fullname");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Gender");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Password");

                    b.Property<int>("roleId")
                        .HasColumnType("integer")
                        .HasColumnName("RoleId");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Username");

                    b.HasKey("userId");

                    b.HasIndex("roleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.Bill", b =>
                {
                    b.HasOne("Entities.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Bills")
                        .HasForeignKey("paymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.BillProduct", b =>
                {
                    b.HasOne("Entities.Models.Bill", "bill")
                        .WithMany("BillProducts")
                        .HasForeignKey("billId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany("BillProducts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("bill");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.OtpCode", b =>
                {
                    b.HasOne("Entities.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.HasOne("Entities.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entities.Models.Bill", b =>
                {
                    b.Navigation("BillProducts");
                });

            modelBuilder.Entity("Entities.Models.PaymentMethod", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Navigation("BillProducts");
                });

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Categories");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
