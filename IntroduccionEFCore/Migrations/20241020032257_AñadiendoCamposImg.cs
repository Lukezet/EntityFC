using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AñadiendoCamposImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgProfesional",
                table: "Profesionales",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgPrestador",
                table: "Prestadores",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortadaImg",
                table: "Prestadores",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgProfesional",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "ImgPrestador",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "PortadaImg",
                table: "Prestadores");
        }
    }
}
