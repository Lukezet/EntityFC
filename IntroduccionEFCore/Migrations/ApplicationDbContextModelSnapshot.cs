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

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("FechaAnula")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int?>("ProfesionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfesionalId")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
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
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnOrder(10);

                    b.Property<string>("Direccion")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(5);

                    b.Property<string>("Eslogan")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("FechaAnula")
                        .HasColumnType("datetime")
                        .HasColumnOrder(7);

                    b.Property<DateTime>("FechaCrea")
                        .HasColumnType("datetime")
                        .HasColumnOrder(6);

                    b.Property<string>("ImgPrestador")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(2);

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(9);

                    b.Property<string>("PortadaImg")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(8);

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Profesional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("FechaAnula")
                        .HasColumnType("datetime")
                        .HasColumnOrder(7);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime")
                        .HasColumnOrder(6);

                    b.Property<int?>("IdentificadorNacional")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<string>("ImgProfesional")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnOrder(2);

                    b.Property<int>("PrestadorId")
                        .HasColumnType("int");

                    b.Property<long?>("Telefono")
                        .HasColumnType("bigint")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.ToTable("Profesionales");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            Logo = "./src/assets/mop.png",
                            Nombre = "Limpieza"
                        },
                        new
                        {
                            Id = 10,
                            Logo = "./src/assets/gardener.png",
                            Nombre = "Jardinería"
                        },
                        new
                        {
                            Id = 11,
                            Logo = "./src/assets/carpenter.png",
                            Nombre = "Carpintería"
                        },
                        new
                        {
                            Id = 12,
                            Logo = "./src/assets/paint-roller.png",
                            Nombre = "Pintura"
                        },
                        new
                        {
                            Id = 13,
                            Logo = "./src/assets/bricklayer.png",
                            Nombre = "Albañilería"
                        },
                        new
                        {
                            Id = 14,
                            Logo = "./src/assets/locksmith.png",
                            Nombre = "Cerrajería"
                        },
                        new
                        {
                            Id = 15,
                            Logo = "./src/assets/appliance-repair.png",
                            Nombre = "Reparación de Electrodomésticos"
                        },
                        new
                        {
                            Id = 16,
                            Logo = "./src/assets/nanny.png",
                            Nombre = "Niñeras"
                        },
                        new
                        {
                            Id = 17,
                            Logo = "./src/assets/insurance.png",
                            Nombre = "Alarmas y Seguridad"
                        },
                        new
                        {
                            Id = 18,
                            Logo = "./src/assets/vet.png",
                            Nombre = "Veterinaria"
                        },
                        new
                        {
                            Id = 19,
                            Logo = "./src/assets/moving-truck.png",
                            Nombre = "Mudanzas"
                        });
                });

            modelBuilder.Entity("IntroduccionEFCore.Entidades.Usuario", b =>
                {
                    b.HasOne("ServicaDB.Entidades.Profesional", "Profesional")
                        .WithOne("Usuario")
                        .HasForeignKey("IntroduccionEFCore.Entidades.Usuario", "ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Profesional");
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

            modelBuilder.Entity("ServicaDB.Entidades.Profesional", b =>
                {
                    b.HasOne("ServicaDB.Entidades.Prestador", "Prestador")
                        .WithMany("Profesionales")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Prestador", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Profesionales");
                });

            modelBuilder.Entity("ServicaDB.Entidades.Profesional", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
