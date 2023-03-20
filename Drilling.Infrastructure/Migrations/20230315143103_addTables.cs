using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drilling.Infrastructure.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "DrillBlocks",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "DrillBlockPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrillBlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    Z = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlockPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillBlockPoints_DrillBlocks_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "DrillBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DrillBlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    Depth = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holes_DrillBlocks_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "DrillBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolePoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    Z = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolePoints_Holes_HoleId",
                        column: x => x.HoleId,
                        principalTable: "Holes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlockPoints_DrillBlockId",
                table: "DrillBlockPoints",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints",
                column: "HoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Holes_DrillBlockId",
                table: "Holes",
                column: "DrillBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrillBlockPoints");

            migrationBuilder.DropTable(
                name: "HolePoints");

            migrationBuilder.DropTable(
                name: "Holes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateTime",
                table: "DrillBlocks",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
