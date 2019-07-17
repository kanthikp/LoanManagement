using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    InterestRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserLoanNum = table.Column<string>(nullable: false),
                    InterestAmount = table.Column<double>(nullable: false),
                    EarlyPaymentFee = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    AppliedForTopup = table.Column<bool>(nullable: false),
                    LoanMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoans_LoanMasters_LoanMasterId",
                        column: x => x.LoanMasterId,
                        principalTable: "LoanMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoanMasters",
                columns: new[] { "Id", "CreatedOn", "InterestRate", "Name", "Type", "UpdatedOn" },
                values: new object[] { 1, new DateTime(2019, 7, 17, 2, 3, 37, 593, DateTimeKind.Local).AddTicks(8861), 3.5, "asd", "Personal", new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(970) });

            migrationBuilder.InsertData(
                table: "LoanMasters",
                columns: new[] { "Id", "CreatedOn", "InterestRate", "Name", "Type", "UpdatedOn" },
                values: new object[] { 2, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(1413), 4.5, "dfe", "Personal", new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(1421) });

            migrationBuilder.InsertData(
                table: "LoanMasters",
                columns: new[] { "Id", "CreatedOn", "InterestRate", "Name", "Type", "UpdatedOn" },
                values: new object[] { 3, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(1426), 2.5, "wer", "Personal", new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(1428) });

            migrationBuilder.InsertData(
                table: "UserLoans",
                columns: new[] { "Id", "AppliedForTopup", "Balance", "CreatedOn", "EarlyPaymentFee", "InterestAmount", "LoanMasterId", "UpdatedOn", "UserId", "UserLoanNum" },
                values: new object[,]
                {
                    { 1, false, 1870.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5453), 67.0, 324.0, 1, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5460), 1, "678523187" },
                    { 2, false, 1902.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5488), 34.0, 546.0, 1, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5490), 2, "345785234" },
                    { 5, false, 1647.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5502), 89.0, 456.0, 1, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5504), 3, "234677345" },
                    { 3, false, 3234.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5494), 267.0, 233.0, 2, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5495), 2, "432578456" },
                    { 4, false, 4678.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5498), 464.0, 234.0, 2, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5500), 3, "245356733" },
                    { 6, false, 1094.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5509), 102.0, 343.0, 2, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5511), 3, "549785345" },
                    { 7, false, 2644.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5513), 98.0, 123.0, 3, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5515), 4, "456845676" },
                    { 8, false, 2355.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5518), 74.0, 435.0, 3, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5520), 4, "345689678" },
                    { 9, false, 2345.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5522), 82.0, 265.0, 3, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5524), 4, "985467845" },
                    { 10, false, 2345.0, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5527), 82.0, 265.0, 3, new DateTime(2019, 7, 17, 2, 3, 37, 595, DateTimeKind.Local).AddTicks(5529), 4, "985435846" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoans_LoanMasterId",
                table: "UserLoans",
                column: "LoanMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoans");

            migrationBuilder.DropTable(
                name: "LoanMasters");
        }
    }
}
