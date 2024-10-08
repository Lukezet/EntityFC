﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            var cienciaFiccion = new Servicio { Id = 5, Nombre = "Ciencia Ficcion" };
            var animacion = new Servicio { Id = 6, Nombre = "Animacion" };
            builder.HasData(cienciaFiccion, animacion);


        }
    }
}
