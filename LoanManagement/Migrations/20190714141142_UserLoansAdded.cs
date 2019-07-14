using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class UserLoansAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 14, 19, 36, 55, 171, DateTimeKind.Local).AddTicks(187), new DateTime(2019, 7, 14, 19, 36, 55, 172, DateTimeKind.Local).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 14, 19, 36, 55, 172, DateTimeKind.Local).AddTicks(4288), new DateTime(2019, 7, 14, 19, 36, 55, 172, DateTimeKind.Local).AddTicks(4297) });

            migrationBuilder.UpdateData(
                table: "LoanMasters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 7, 14, 19, 36, 55, 172, DateTimeKind.Local).AddTicks(4303), new DateTime(2019, 7, 14, 19, 36, 55, 172, DateTimeKind.Local).AddTicks(4306) });
        }
    }
}
