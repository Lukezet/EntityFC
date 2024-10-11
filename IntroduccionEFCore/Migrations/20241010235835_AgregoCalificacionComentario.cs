using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AgregoCalificacionComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recomendar",
                table: "Comentarios");

            migrationBuilder.AddColumn<int>(
                name: "Calificacion",
                table: "Comentarios",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Comentarios");

            migrationBuilder.AddColumn<bool>(
                name: "Recomendar",
                table: "Comentarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
