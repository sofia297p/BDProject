using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sanatorium.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "alcoholic_inspector_id_fkey",
                table: "alcoholic_inspector");

            migrationBuilder.DropForeignKey(
                name: "alcoholic_inspector_id_fkey1",
                table: "alcoholic_inspector");

            migrationBuilder.DropTable(
                name: "put_alcoholic_bed");

            migrationBuilder.DropTable(
                name: "release_alcoholic_bed");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "alcoholic_inspector",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "alcoholic_inspector",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_alcoholic_inspector_BedId",
                table: "alcoholic_inspector",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_alcoholic_inspector_bed_BedId",
                table: "alcoholic_inspector",
                column: "BedId",
                principalTable: "bed",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alcoholic_inspector_bed_BedId",
                table: "alcoholic_inspector");

            migrationBuilder.DropIndex(
                name: "IX_alcoholic_inspector_BedId",
                table: "alcoholic_inspector");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "alcoholic_inspector");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "alcoholic_inspector",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "put_alcoholic_bed",
                columns: table => new
                {
                    pair_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bed_id = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("put_alcoholic_bed_pkey", x => x.pair_id);
                    table.ForeignKey(
                        name: "put_alcoholic_bed_bed_id_fkey",
                        column: x => x.bed_id,
                        principalTable: "bed",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "release_alcoholic_bed",
                columns: table => new
                {
                    pair_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bed_id = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("release_alcoholic_bed_pkey", x => x.pair_id);
                    table.ForeignKey(
                        name: "release_alcoholic_bed_bed_id_fkey",
                        column: x => x.bed_id,
                        principalTable: "bed",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_put_alcoholic_bed_bed_id",
                table: "put_alcoholic_bed",
                column: "bed_id");

            migrationBuilder.CreateIndex(
                name: "IX_release_alcoholic_bed_bed_id",
                table: "release_alcoholic_bed",
                column: "bed_id");

            migrationBuilder.AddForeignKey(
                name: "alcoholic_inspector_id_fkey",
                table: "alcoholic_inspector",
                column: "id",
                principalTable: "put_alcoholic_bed",
                principalColumn: "pair_id");

            migrationBuilder.AddForeignKey(
                name: "alcoholic_inspector_id_fkey1",
                table: "alcoholic_inspector",
                column: "id",
                principalTable: "release_alcoholic_bed",
                principalColumn: "pair_id");
        }
    }
}
