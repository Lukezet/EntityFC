using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddingPrestadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Peliculas_PeliculaId",
                table: "Comentarios");

            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "PeliculaServicio");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.RenameColumn(
                name: "PeliculaId",
                table: "Comentarios",
                newName: "PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PeliculaId",
                table: "Comentarios",
                newName: "IX_Comentarios_PrestadorId");

            migrationBuilder.CreateTable(
                name: "Prestadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EnCines = table.Column<bool>(type: "bit", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrestadoresActores",
                columns: table => new
                {
                    PrestadorId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadoresActores", x => new { x.ActorId, x.PrestadorId });
                    table.ForeignKey(
                        name: "FK_PrestadoresActores_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestadoresActores_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrestadoresActores_PrestadorId",
                table: "PrestadoresActores",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorServicio_ServiciosId",
                table: "PrestadorServicio",
                column: "ServiciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Prestadores_PrestadorId",
                table: "Comentarios",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Prestadores_PrestadorId",
                table: "Comentarios");

            migrationBuilder.DropTable(
                name: "PrestadoresActores");

            migrationBuilder.DropTable(
                name: "PrestadorServicio");

            migrationBuilder.DropTable(
                name: "Prestadores");

            migrationBuilder.RenameColumn(
                name: "PrestadorId",
                table: "Comentarios",
                newName: "PeliculaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PrestadorId",
                table: "Comentarios",
                newName: "IX_Comentarios_PeliculaId");

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnCines = table.Column<bool>(type: "bit", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "datetime", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasActores",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasActores", x => new { x.ActorId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaServicio",
                columns: table => new
                {
                    PeliculasId = table.Column<int>(type: "int", nullable: false),
                    ServiciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaServicio", x => new { x.PeliculasId, x.ServiciosId });
                    table.ForeignKey(
                        name: "FK_PeliculaServicio_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaServicio_Servicios_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_PeliculaId",
                table: "PeliculasActores",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaServicio_ServiciosId",
                table: "PeliculaServicio",
                column: "ServiciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Peliculas_PeliculaId",
                table: "Comentarios",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
