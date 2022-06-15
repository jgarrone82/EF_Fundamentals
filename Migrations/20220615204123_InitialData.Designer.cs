﻿// <auto-generated />
using System;
using EF_Fundamentals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Fundamentals.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20220615204123_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EF_Fundamentals.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Effort")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"),
                            Effort = 20,
                            Name = "Pending activities"
                        },
                        new
                        {
                            CategoryId = new Guid("943283c8-49fa-47a5-a28b-7e80780e4d2e"),
                            Effort = 50,
                            Name = "Personal activities"
                        });
                });

            modelBuilder.Entity("EF_Fundamentals.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("b0f4153b-b754-4a15-bac0-fa0f38abf17e"),
                            CategoryId = new Guid("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"),
                            CreationDate = new DateTime(2022, 6, 15, 16, 41, 23, 637, DateTimeKind.Local).AddTicks(1367),
                            PriorityTask = 1,
                            Title = "Payment of public services"
                        },
                        new
                        {
                            TaskId = new Guid("e4f1353a-dca2-48cf-bb23-01ca026e6824"),
                            CategoryId = new Guid("943283c8-49fa-47a5-a28b-7e80780e4d2e"),
                            CreationDate = new DateTime(2022, 6, 15, 16, 41, 23, 637, DateTimeKind.Local).AddTicks(1405),
                            PriorityTask = 0,
                            Title = "Finish watching movie"
                        });
                });

            modelBuilder.Entity("EF_Fundamentals.Models.Task", b =>
                {
                    b.HasOne("EF_Fundamentals.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EF_Fundamentals.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
