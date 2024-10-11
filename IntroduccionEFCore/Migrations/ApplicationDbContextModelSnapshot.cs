﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicaDB;

#nullable disable

namespace IntroduccionEFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

            modelBuilder.Entity("ServicaDB.Entidades.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Calificacion")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Contenido")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("PrestadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Prestador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("EnCines")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("datetime");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("ServicaDB.Entidades.PrestadorProfesional", b =>
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
                        .HasColumnType("varchar(150)");

                    b.HasKey("ProfesionalId", "PrestadorId");

                    b.HasIndex("PrestadorId");

                    b.ToTable("PrestadoresProfesionales");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Profesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Fortuna")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Profesionales");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

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
                    b.HasOne("ServicaDB.Entidades.Prestador", null)
                        .WithMany()
                        .HasForeignKey("PrestadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicaDB.Entidades.Servicio", null)
                        .WithMany()
                        .HasForeignKey("ServiciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServicaDB.Entidades.Comentario", b =>
                {
                    b.HasOne("ServicaDB.Entidades.Prestador", "Prestador")
                        .WithMany("Comentarios")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("ServicaDB.Entidades.PrestadorProfesional", b =>
                {
                    b.HasOne("ServicaDB.Entidades.Prestador", "Prestador")
                        .WithMany("PrestadoresProfesionales")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicaDB.Entidades.Profesional", "Profesional")
                        .WithMany("PrestadoresProfesionales")
                        .HasForeignKey("ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");

                    b.Navigation("Profesional");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Prestador", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("PrestadoresProfesionales");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Profesional", b =>
                {
                    b.Navigation("PrestadoresProfesionales");
                });
#pragma warning restore 612, 618
        }
    }
}
