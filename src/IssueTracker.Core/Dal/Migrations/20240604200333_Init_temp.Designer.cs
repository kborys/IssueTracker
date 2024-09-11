﻿// <auto-generated />
using System;
using IssueTracker.Core.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IssueTracker.Core.Dal.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20240604200333_Init_temp")]
    partial class Init_temp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("core")
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IssueTracker.Core.Entities.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AssignedToId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("IssueId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("IssueId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Issues", "core");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.IssueComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IssueId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParentCommentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("IssueId");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("IssueComment", "core");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Projects", "core");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "core");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.Issue", b =>
                {
                    b.HasOne("IssueTracker.Core.Entities.User", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId");

                    b.HasOne("IssueTracker.Core.Entities.User", "CreatedBy")
                        .WithMany("Issues")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IssueTracker.Core.Entities.Issue", null)
                        .WithMany("SubIssues")
                        .HasForeignKey("IssueId");

                    b.HasOne("IssueTracker.Core.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("CreatedBy");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.IssueComment", b =>
                {
                    b.HasOne("IssueTracker.Core.Entities.User", "CreatedBy")
                        .WithMany("IssueComments")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Core.Entities.Issue", null)
                        .WithMany("Comments")
                        .HasForeignKey("IssueId");

                    b.HasOne("IssueTracker.Core.Entities.IssueComment", "ParentComment")
                        .WithMany()
                        .HasForeignKey("ParentCommentId");

                    b.Navigation("CreatedBy");

                    b.Navigation("ParentComment");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.Project", b =>
                {
                    b.HasOne("IssueTracker.Core.Entities.User", "CreatedBy")
                        .WithMany("Projects")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.Issue", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("SubIssues");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.Project", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("IssueTracker.Core.Entities.User", b =>
                {
                    b.Navigation("IssueComments");

                    b.Navigation("Issues");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
