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
                name: "Loans",
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
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "CreatedOn", "InterestRate", "Name", "Type", "UpdatedOn" },
                values: new object[] { 1, new DateTime(2019, 7, 14, 18, 50, 1, 357, DateTimeKind.Local).AddTicks(1974), 3.5, "asd", "Personal", new DateTime(2019, 7, 14, 18, 50, 1, 358, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "CreatedOn", "InterestRate", "Name", "Type", "UpdatedOn" },
                values: new object[] { 2, new DateTime(2019, 7, 14, 18, 50, 1, 358, DateTimeKind.Local).AddTicks(5767), 4.5, "dfe", "Personal", new DateTime(2019, 7, 14, 18, 50, 1, 358, DateTimeKind.Local).AddTicks(5777) });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "CreatedOn", "InterestRate", "Name", "Type", "UpdatedOn" },
                values: new object[] { 3, new DateTime(2019, 7, 14, 18, 50, 1, 358, DateTimeKind.Local).AddTicks(5782), 2.5, "wer", "Personal", new DateTime(2019, 7, 14, 18, 50, 1, 358, DateTimeKind.Local).AddTicks(5785) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
