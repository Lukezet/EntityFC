using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPeliculaComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEstreno",
                table: "Peliculas",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Actores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PeliculaId",
                table: "Comentarios",
                column: "PeliculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Peliculas_PeliculaId",
                table: "Comentarios",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Peliculas_PeliculaId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PeliculaId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEstreno",
                table: "Peliculas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Actores",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
