﻿using ServicaDB.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IntroduccionEFCore.Entidades;

namespace ServicaDB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //API FLUENTE
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//nunca borrar esto
            //AQUI TAMBIEN PODEMOS HACER LAS CONFIGURACIONES PERO LO HACEMOS EN Entidades/Configuraciones
            //modelBuilder.Entity<Comentario>().Property(g => g.Contenido).HasMaxLength(300);//Aclaramos que el maximo de caract de Nombre es 300

            //este assembly es el que hara posible ejecutar las configuraciones que estan por fuera 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)//HACEMOS ESTA CONFIGURACION DE CONVENCIONES
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);//PARA QUE POR DEFECTO LOS CAMPOS STRING SE VAN A CONFIGURAR 150
        }
        public DbSet<Servicio> Servicios => Set<Servicio>();
        public DbSet<Profesional> Profesionales => Set<Profesional>();
        public DbSet<Prestador> Prestadores => Set<Prestador>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

    }
}
