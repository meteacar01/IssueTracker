﻿// <auto-generated />
using System;
using IssueTracker.DbAccessContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IssueTracker.Migrations
{
    [DbContext(typeof(PostgreContext))]
    partial class PostgreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("IssueTracker.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("IssueTracker.Models.Iteration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Iteration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Iteration 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Iteration 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Iteration 3"
                        });
                });

            modelBuilder.Entity("IssueTracker.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 26, 18, 13, 38, 881, DateTimeKind.Local).AddTicks(4209),
                            Name = "meteacar01"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 26, 18, 13, 38, 883, DateTimeKind.Local).AddTicks(2800),
                            Name = "duyguacar01"
                        });
                });

            modelBuilder.Entity("IssueTracker.Models.WorkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AssignedTo")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<int>("IterationId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("WorkItemStateId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkItemTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IterationId");

                    b.HasIndex("WorkItemStateId");

                    b.HasIndex("WorkItemTypeId");

                    b.ToTable("WorkItem");
                });

            modelBuilder.Entity("IssueTracker.Models.WorkItemComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("CommentId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("WorkItemComments");
                });

            modelBuilder.Entity("IssueTracker.Models.WorkItemState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("WorkItemState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Open"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Closed"
                        });
                });

            modelBuilder.Entity("IssueTracker.Models.WorkItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("WorkItemType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bug"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Feature"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Task"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Epic"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Issue"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Test Case"
                        },
                        new
                        {
                            Id = 7,
                            Name = "User Story"
                        });
                });

            modelBuilder.Entity("IssueTracker.Models.WorkItem", b =>
                {
                    b.HasOne("IssueTracker.Models.Iteration", "Iteration")
                        .WithMany()
                        .HasForeignKey("IterationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.WorkItemState", "WorkItemState")
                        .WithMany()
                        .HasForeignKey("WorkItemStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.WorkItemType", "WorkItemType")
                        .WithMany()
                        .HasForeignKey("WorkItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iteration");

                    b.Navigation("WorkItemState");

                    b.Navigation("WorkItemType");
                });

            modelBuilder.Entity("IssueTracker.Models.WorkItemComments", b =>
                {
                    b.HasOne("IssueTracker.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.WorkItem", "WorkItem")
                        .WithMany()
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("WorkItem");
                });
#pragma warning restore 612, 618
        }
    }
}
