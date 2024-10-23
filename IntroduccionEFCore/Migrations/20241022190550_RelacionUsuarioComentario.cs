using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUsuarioComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefono",
                table: "Prestadores",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "Provincia",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "Pais",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCrea",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaAnula",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "Eslogan",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Prestadores",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Prestadores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAnula",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCrea",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "FechaAnula",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "FechaCrea",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<long>(
                name: "Telefono",
                table: "Prestadores",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "Provincia",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "Pais",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCrea",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaAnula",
                table: "Prestadores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "Eslogan",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Prestadores",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Prestadores",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Prestadores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}
