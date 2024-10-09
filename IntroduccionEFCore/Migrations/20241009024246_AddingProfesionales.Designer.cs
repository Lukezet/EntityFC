﻿// <auto-generated />
using System;
using IntroduccionEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241009024246_AddingProfesionales")]
    partial class AddingProfesionales
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("PrestadorId")
                        .HasColumnType("int");

                    b.Property<bool>("Recomendar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Prestador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EnCines")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("datetime");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.PrestadorProfesional", b =>
                {
                    b.Property<int>("ProfesionalId")
                        .HasColumnType("int");

                    b.Property<int>("PrestadorId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProfesionalId", "PrestadorId");

                    b.HasIndex("PrestadorId");

                    b.ToTable("PrestadoresProfesionales");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Profesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Fortuna")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Profesionales");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Nombre = "Ciencia Ficcion"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Animacion"
                        });
                });

            modelBuilder.Entity("PrestadorServicio", b =>
                {
                    b.Property<int>("PrestadoresId")
                        .HasColumnType("int");

                    b.Property<int>("ServiciosId")
                        .HasColumnType("int");

                    b.HasKey("PrestadoresId", "ServiciosId");

                    b.HasIndex("ServiciosId");

                    b.ToTable("PrestadorServicio");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Comentario", b =>
                {
                    b.HasOne("IntroduccionEFCore.Entidades.Prestador", "Prestador")
                        .WithMany("Comentarios")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.PrestadorProfesional", b =>
                {
                    b.HasOne("IntroduccionEFCore.Entidades.Prestador", "Prestador")
                        .WithMany("PrestadoresProfesionales")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntroduccionEFCore.Entidades.Profesional", "Profesional")
                        .WithMany("PrestadoresProfesionales")
                        .HasForeignKey("ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");

                    b.Navigation("Profesional");
                });

            modelBuilder.Entity("PrestadorServicio", b =>
                {
                    b.HasOne("IntroduccionEFCore.Entidades.Prestador", null)
                        .WithMany()
                        .HasForeignKey("PrestadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntroduccionEFCore.Entidades.Servicio", null)
                        .WithMany()
                        .HasForeignKey("ServiciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Prestador", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("PrestadoresProfesionales");
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Profesional", b =>
                {
                    b.Navigation("PrestadoresProfesionales");
                });
#pragma warning restore 612, 618
        }
    }
}
