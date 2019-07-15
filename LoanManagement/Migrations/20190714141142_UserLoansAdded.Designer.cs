﻿// <auto-generated />
using System;
using LoanManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanManagement.Migrations
{
    [DbContext(typeof(LoanMgmtContext))]
    [Migration("20190714141142_UserLoansAdded")]
    partial class UserLoansAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoanManagement.Domain.LoanMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<double>("InterestRate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("LoanMasters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 11, 42, 64, DateTimeKind.Local).AddTicks(7913),
                            InterestRate = 3.5,
                            Name = "asd",
                            Type = "Personal",
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 11, 42, 65, DateTimeKind.Local).AddTicks(9820)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(282),
                            InterestRate = 4.5,
                            Name = "dfe",
                            Type = "Personal",
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(290)
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(296),
                            InterestRate = 2.5,
                            Name = "wer",
                            Type = "Personal",
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(298)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}