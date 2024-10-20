using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class prueba2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 9,
                column: "Logo",
                value: "./src/assets/mop.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 10,
                column: "Logo",
                value: "./src/assets/gardener.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 11,
                column: "Logo",
                value: "./src/assets/carpenter.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 12,
                column: "Logo",
                value: "./src/assets/paint-roller.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 13,
                column: "Logo",
                value: "./src/assets/bricklayer.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 14,
                column: "Logo",
                value: "./src/assets/locksmith.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 15,
                column: "Logo",
                value: "./src/assets/appliance-repair.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Logo", "Nombre" },
                values: new object[] { "./src/assets/nanny.png", "Niñeras" });

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 17,
                column: "Logo",
                value: "./src/assets/insurance.png");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Logo", "Nombre" },
                values: new object[] { "./src/assets/vet.png", "Veterinaria" });

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 19,
                column: "Logo",
                value: "./src/assets/moving-truck.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 9,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 10,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 11,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 12,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 13,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 14,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 15,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Logo", "Nombre" },
                values: new object[] { null, "Mantenimiento de Piscinas" });

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 17,
                column: "Logo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Logo", "Nombre" },
                values: new object[] { null, "Instalación y reparacion de Aires Acondicionados" });

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "Id",
                keyValue: 19,
                column: "Logo",
                value: null);
        }
    }
}
