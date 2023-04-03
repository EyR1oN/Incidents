﻿// <auto-generated />
using Incidents.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Incidents.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230403132419_null")]
    partial class @null
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Incidents.DAL.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IncidentId = 1,
                            Name = "Account 1"
                        },
                        new
                        {
                            Id = 2,
                            IncidentId = 1,
                            Name = "Account 2"
                        },
                        new
                        {
                            Id = 3,
                            IncidentId = 2,
                            Name = "Account 3"
                        });
                });

            modelBuilder.Entity("Incidents.DAL.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Contact");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Email = "Contact1@gmail.com",
                            FirstName = "FirstName 1",
                            LastName = "LastName 1"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            Email = "Contact2@gmail.com",
                            FirstName = "FirstName 2",
                            LastName = "LastName 2"
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 1,
                            Email = "Contact3@gmail.com",
                            FirstName = "FirstName 3",
                            LastName = "LastName 3"
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 2,
                            Email = "Contact4@gmail.com",
                            FirstName = "FirstName 4",
                            LastName = "LastName 4"
                        },
                        new
                        {
                            Id = 5,
                            AccountId = 2,
                            Email = "Contact5@gmail.com",
                            FirstName = "FirstName 5",
                            LastName = "LastName 5"
                        },
                        new
                        {
                            Id = 6,
                            AccountId = 3,
                            Email = "Contact6@gmail.com",
                            FirstName = "FirstName 6",
                            LastName = "LastName 6"
                        });
                });

            modelBuilder.Entity("Incidents.DAL.Entities.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Incident");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Incident Description 1",
                            Name = "Incident 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Incident Description 2",
                            Name = "Incident 2"
                        });
                });

            modelBuilder.Entity("Incidents.DAL.Entities.Account", b =>
                {
                    b.HasOne("Incidents.DAL.Entities.Incident", "Incident")
                        .WithMany("Accounts")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("Incidents.DAL.Entities.Contact", b =>
                {
                    b.HasOne("Incidents.DAL.Entities.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Incidents.DAL.Entities.Account", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Incidents.DAL.Entities.Incident", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
