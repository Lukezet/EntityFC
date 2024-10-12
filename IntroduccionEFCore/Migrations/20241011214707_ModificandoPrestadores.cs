using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoPrestadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnCines",
                table: "Prestadores");

            // Eliminar la columna Titulo
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Prestadores");

            // Agregar la nueva columna Provincia
            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Prestadores",
                type: "nvarchar(100)",  // Ajusta el tipo de dato y tamaño según sea necesario
                nullable: false,
                defaultValue: "");

            // Eliminar la columna FechaEstreno
            migrationBuilder.DropColumn(
                name: "FechaEstreno",
                table: "Prestadores");

            // Agregar la nueva columna FechaCrea
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCrea",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                defaultValue: DateTime.Now); // Usa DateTime.UtcNow si prefieres UTC

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Servicios",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Prestadores",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eslogan",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAnula",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Prestadores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Eslogan",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "FechaAnula",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Prestadores");

            // Eliminar la columna Provincia
            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Prestadores");

            // Restaurar la columna Titulo
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Prestadores",
                type: "nvarchar(100)",  // Ajusta el tipo de dato y tamaño según sea necesario
                nullable: false,
                defaultValue: "");

            // Eliminar la columna FechaCrea
            migrationBuilder.DropColumn(
                name: "FechaCrea",
                table: "Prestadores");

            // Restaurar la columna FechaEstreno
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEstreno",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                defaultValue: DateTime.Now); // Ajusta según sea necesario

            migrationBuilder.AddColumn<bool>(
                name: "EnCines",
                table: "Prestadores",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
