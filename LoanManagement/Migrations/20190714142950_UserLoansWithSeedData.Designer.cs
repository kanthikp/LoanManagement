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
    [Migration("20190714142950_UserLoansWithSeedData")]
    partial class UserLoansWithSeedData
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
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 591, DateTimeKind.Local).AddTicks(5495),
                            InterestRate = 3.5,
                            Name = "asd",
                            Type = "Personal",
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8442)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8922),
                            InterestRate = 4.5,
                            Name = "dfe",
                            Type = "Personal",
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8931)
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8936),
                            InterestRate = 2.5,
                            Name = "wer",
                            Type = "Personal",
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8938)
                        });
                });

            modelBuilder.Entity("LoanManagement.Domain.UserLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AppliedForTopup");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<double>("EarlyPaymentFee");

                    b.Property<double>("Interest");

                    b.Property<int>("LoanMasterId");

                    b.Property<double>("Payout");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("UserLoanId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LoanMasterId");

                    b.ToTable("UserLoans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3292),
                            EarlyPaymentFee = 67.0,
                            Interest = 324.0,
                            LoanMasterId = 1,
                            Payout = 1870.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3305),
                            UserLoanId = "678523187"
                        },
                        new
                        {
                            Id = 2,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3331),
                            EarlyPaymentFee = 34.0,
                            Interest = 546.0,
                            LoanMasterId = 1,
                            Payout = 1902.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3333),
                            UserLoanId = "345785234"
                        },
                        new
                        {
                            Id = 3,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3336),
                            EarlyPaymentFee = 267.0,
                            Interest = 233.0,
                            LoanMasterId = 2,
                            Payout = 3234.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3338),
                            UserLoanId = "432578456"
                        },
                        new
                        {
                            Id = 4,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3340),
                            EarlyPaymentFee = 464.0,
                            Interest = 234.0,
                            LoanMasterId = 2,
                            Payout = 4678.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3342),
                            UserLoanId = "245356733"
                        },
                        new
                        {
                            Id = 5,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3345),
                            EarlyPaymentFee = 89.0,
                            Interest = 456.0,
                            LoanMasterId = 1,
                            Payout = 1647.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3347),
                            UserLoanId = "234677345"
                        },
                        new
                        {
                            Id = 6,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3351),
                            EarlyPaymentFee = 102.0,
                            Interest = 343.0,
                            LoanMasterId = 2,
                            Payout = 1094.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3353),
                            UserLoanId = "549785345"
                        },
                        new
                        {
                            Id = 7,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3355),
                            EarlyPaymentFee = 98.0,
                            Interest = 123.0,
                            LoanMasterId = 3,
                            Payout = 2644.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3357),
                            UserLoanId = "456845676"
                        },
                        new
                        {
                            Id = 8,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3360),
                            EarlyPaymentFee = 74.0,
                            Interest = 435.0,
                            LoanMasterId = 3,
                            Payout = 2355.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3362),
                            UserLoanId = "345689678"
                        },
                        new
                        {
                            Id = 9,
                            AppliedForTopup = false,
                            CreatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3364),
                            EarlyPaymentFee = 82.0,
                            Interest = 265.0,
                            LoanMasterId = 3,
                            Payout = 2345.0,
                            UpdatedOn = new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3366),
                            UserLoanId = "985467845"
                        });
                });

            modelBuilder.Entity("LoanManagement.Domain.UserLoan", b =>
                {
                    b.HasOne("LoanManagement.Domain.LoanMaster", "LoanMaster")
                        .WithMany()
                        .HasForeignKey("LoanMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}