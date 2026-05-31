using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedTwoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<double>(type: "float(5)", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PcComponents",
                columns: table => new
                {
                    PcId = table.Column<int>(type: "int", nullable: false),
                    ComponentCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcComponents", x => new { x.PcId, x.ComponentCode });
                    table.ForeignKey(
                        name: "FK_PcComponents_Components_ComponentCode",
                        column: x => x.ComponentCode,
                        principalTable: "Components",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcComponents_Pc_PcId",
                        column: x => x.PcId,
                        principalTable: "Pc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pc",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dell XPS 15", 15, 24, 1.8600000000000001 },
                    { 2, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "HP Spectre x360", 8, 12, 1.3400000000000001 },
                    { 3, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lenovo ThinkPad X1", 22, 36, 1.1200000000000001 }
                });

            migrationBuilder.InsertData(
                table: "PcComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "GPU-RX580", 1, 1 },
                    { "CPU-R5600", 2, 2 },
                    { "RAM-16DDR4", 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PcComponents_ComponentCode",
                table: "PcComponents",
                column: "ComponentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PcComponents");

            migrationBuilder.DropTable(
                name: "Pc");
        }
    }
}
