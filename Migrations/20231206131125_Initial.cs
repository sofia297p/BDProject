using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sanatorium.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bed",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bed", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drink_process",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_alcoholic_id = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    drink_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drink_process", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drink_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    alcohol_degree = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drink_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groupa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    surname = table.Column<string>(type: "character varying", nullable: true),
                    birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    sex = table.Column<string>(type: "character varying", nullable: true),
                    email = table.Column<string>(type: "character varying", nullable: true),
                    password = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "alcoholic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    consciousness = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alcoholic", x => x.id);
                    table.ForeignKey(
                        name: "alcoholic_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inspector",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspector", x => x.id);
                    table.ForeignKey(
                        name: "inspector_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "escape_from_bed",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alcoholic_id = table.Column<int>(type: "integer", nullable: true),
                    bed_id = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escape_from_bed", x => x.id);
                    table.ForeignKey(
                        name: "escape_from_bed_alcoholic_id_fkey",
                        column: x => x.alcoholic_id,
                        principalTable: "alcoholic",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "escape_from_bed_bed_id_fkey",
                        column: x => x.bed_id,
                        principalTable: "bed",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "group_alcoholic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_id = table.Column<int>(type: "integer", nullable: true),
                    alcoholic_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_alcoholic", x => x.id);
                    table.ForeignKey(
                        name: "group_alcoholic_alcoholic_id_fkey",
                        column: x => x.alcoholic_id,
                        principalTable: "alcoholic",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "group_alcoholic_group_id_fkey",
                        column: x => x.group_id,
                        principalTable: "groupa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "alcoholic_inspector",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    inspector_id = table.Column<int>(type: "integer", nullable: true),
                    alcoholic_id = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    state = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alcoholic_inspector", x => x.id);
                    table.ForeignKey(
                        name: "alcoholic_inspector_alcoholic_id_fkey",
                        column: x => x.alcoholic_id,
                        principalTable: "alcoholic",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "alcoholic_inspector_id_fkey",
                        column: x => x.id,
                        principalTable: "put_alcoholic_bed",
                        principalColumn: "pair_id");
                    table.ForeignKey(
                        name: "alcoholic_inspector_id_fkey1",
                        column: x => x.id,
                        principalTable: "release_alcoholic_bed",
                        principalColumn: "pair_id");
                    table.ForeignKey(
                        name: "alcoholic_inspector_inspector_id_fkey",
                        column: x => x.inspector_id,
                        principalTable: "inspector",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_alcoholic_user_id",
                table: "alcoholic",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_alcoholic_inspector_alcoholic_id",
                table: "alcoholic_inspector",
                column: "alcoholic_id");

            migrationBuilder.CreateIndex(
                name: "IX_alcoholic_inspector_inspector_id",
                table: "alcoholic_inspector",
                column: "inspector_id");

            migrationBuilder.CreateIndex(
                name: "IX_escape_from_bed_alcoholic_id",
                table: "escape_from_bed",
                column: "alcoholic_id");

            migrationBuilder.CreateIndex(
                name: "IX_escape_from_bed_bed_id",
                table: "escape_from_bed",
                column: "bed_id");

            migrationBuilder.CreateIndex(
                name: "group_alcoholic_group_id_alcoholic_id_key",
                table: "group_alcoholic",
                columns: new[] { "group_id", "alcoholic_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_alcoholic_alcoholic_id",
                table: "group_alcoholic",
                column: "alcoholic_id");

            migrationBuilder.CreateIndex(
                name: "IX_inspector_user_id",
                table: "inspector",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_put_alcoholic_bed_bed_id",
                table: "put_alcoholic_bed",
                column: "bed_id");

            migrationBuilder.CreateIndex(
                name: "IX_release_alcoholic_bed_bed_id",
                table: "release_alcoholic_bed",
                column: "bed_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alcoholic_inspector");

            migrationBuilder.DropTable(
                name: "drink_process");

            migrationBuilder.DropTable(
                name: "drink_type");

            migrationBuilder.DropTable(
                name: "escape_from_bed");

            migrationBuilder.DropTable(
                name: "group_alcoholic");

            migrationBuilder.DropTable(
                name: "put_alcoholic_bed");

            migrationBuilder.DropTable(
                name: "release_alcoholic_bed");

            migrationBuilder.DropTable(
                name: "inspector");

            migrationBuilder.DropTable(
                name: "alcoholic");

            migrationBuilder.DropTable(
                name: "groupa");

            migrationBuilder.DropTable(
                name: "bed");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
