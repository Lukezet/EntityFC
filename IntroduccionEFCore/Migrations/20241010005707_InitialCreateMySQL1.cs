using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMySQL1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prestadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    EnCines = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadores", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Fortuna = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesionales", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Contenido = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Recomendar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrestadoresProfesionales",
                columns: table => new
                {
                    PrestadorId = table.Column<int>(type: "int", nullable: false),
                    ProfesionalId = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadoresProfesionales", x => new { x.ProfesionalId, x.PrestadorId });
                    table.ForeignKey(
                        name: "FK_PrestadoresProfesionales_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestadoresProfesionales_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrestadorServicio",
                columns: table => new
                {
                    PrestadoresId = table.Column<int>(type: "int", nullable: false),
                    ServiciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorServicio", x => new { x.PrestadoresId, x.ServiciosId });
                    table.ForeignKey(
                        name: "FK_PrestadorServicio_Prestadores_PrestadoresId",
                        column: x => x.PrestadoresId,
                        principalTable: "Prestadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestadorServicio_Servicios_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "Ciencia Ficcion" },
                    { 6, "Animacion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PrestadorId",
                table: "Comentarios",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadoresProfesionales_PrestadorId",
                table: "PrestadoresProfesionales",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorServicio_ServiciosId",
                table: "PrestadorServicio",
                column: "ServiciosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "PrestadoresProfesionales");

            migrationBuilder.DropTable(
                name: "PrestadorServicio");

            migrationBuilder.DropTable(
                name: "Profesionales");

            migrationBuilder.DropTable(
                name: "Prestadores");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
