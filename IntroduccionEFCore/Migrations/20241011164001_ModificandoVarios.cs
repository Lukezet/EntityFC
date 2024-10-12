using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoVarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrestadoresProfesionales");

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Fortuna",
                table: "Profesionales");

            migrationBuilder.DropColumn(
            name: "FechaNacimiento",
            table: "Profesionales");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Profesionales",
                type: "datetime",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Profesionales",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAnula",
                table: "Profesionales",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdentificadorNacional",
                table: "Profesionales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                table: "Profesionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Profesionales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesionales_PrestadorId",
                table: "Profesionales",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Prestadores_PrestadorId",
                table: "Profesionales",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Prestadores_PrestadorId",
                table: "Profesionales");

            migrationBuilder.DropIndex(
                name: "IX_Profesionales_PrestadorId",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "FechaAnula",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "IdentificadorNacional",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Profesionales");

            migrationBuilder.DropColumn(
            name: "FechaCreacion",
            table: "Profesionales");

            // Restaurar la columna FechaNacimiento
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Profesionales",
                type: "datetime",
                nullable: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Fortuna",
                table: "Profesionales",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PrestadoresProfesionales",
                columns: table => new
                {
                    ProfesionalId = table.Column<int>(type: "int", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
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

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "Ciencia Ficcion" },
                    { 6, "Animacion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrestadoresProfesionales_PrestadorId",
                table: "PrestadoresProfesionales",
                column: "PrestadorId");
        }
    }
}
