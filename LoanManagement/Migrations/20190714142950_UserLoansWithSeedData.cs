using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class UserLoansWithSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UserLoanId = table.Column<string>(nullable: false),
                    Interest = table.Column<double>(nullable: false),
                    EarlyPaymentFee = table.Column<double>(nullable: false),
                    Payout = table.Column<double>(nullable: false),
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

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 15, 0, 29, 50, 591, DateTimeKind.Local).AddTicks(5495), new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8922), new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8936), new DateTime(2019, 7, 15, 0, 29, 50, 592, DateTimeKind.Local).AddTicks(8938) });

            migrationBuilder.InsertData(
                table: "UserLoans",
                columns: new[] { "Id", "AppliedForTopup", "CreatedOn", "EarlyPaymentFee", "Interest", "LoanMasterId", "Payout", "UpdatedOn", "UserLoanId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3292), 67.0, 324.0, 1, 1870.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3305), "678523187" },
                    { 2, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3331), 34.0, 546.0, 1, 1902.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3333), "345785234" },
                    { 3, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3336), 267.0, 233.0, 2, 3234.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3338), "432578456" },
                    { 4, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3340), 464.0, 234.0, 2, 4678.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3342), "245356733" },
                    { 5, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3345), 89.0, 456.0, 1, 1647.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3347), "234677345" },
                    { 6, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3351), 102.0, 343.0, 2, 1094.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3353), "549785345" },
                    { 7, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3355), 98.0, 123.0, 3, 2644.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3357), "456845676" },
                    { 8, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3360), 74.0, 435.0, 3, 2355.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3362), "345689678" },
                    { 9, false, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3364), 82.0, 265.0, 3, 2345.0, new DateTime(2019, 7, 15, 0, 29, 50, 593, DateTimeKind.Local).AddTicks(3366), "985467845" }
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

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 15, 0, 11, 42, 64, DateTimeKind.Local).AddTicks(7913), new DateTime(2019, 7, 15, 0, 11, 42, 65, DateTimeKind.Local).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(282), new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(296), new DateTime(2019, 7, 15, 0, 11, 42, 66, DateTimeKind.Local).AddTicks(298) });
        }
    }
}
