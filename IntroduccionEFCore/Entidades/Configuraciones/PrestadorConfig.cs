using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ServicaDB.Entidades.Configuraciones
{
    public class PrestadorConfig : IEntityTypeConfiguration<Prestador>
    {
        public void Configure(EntityTypeBuilder<Prestador> builder)
        {
            builder.Property(g => g.FechaCrea).HasColumnType("datetime");
            builder.Property(g => g.FechaAnula).HasColumnType("datetime");
            builder.Property(g => g.Descripcion).HasMaxLength(300);

            builder.Property(p => p.Id).HasColumnOrder(1);
            builder.Property(p => p.Nombre).HasColumnOrder(2);
            builder.Property(p => p.Eslogan).HasColumnOrder(3);
            builder.Property(p => p.Telefono).HasColumnOrder(4);
            builder.Property(p => p.Direccion).HasColumnOrder(5);
            builder.Property(p => p.FechaCrea).HasColumnOrder(6);
            builder.Property(p => p.FechaAnula).HasColumnOrder(7);
            builder.Property(p => p.Provincia).HasColumnOrder(8);
            builder.Property(p => p.Pais).HasColumnOrder(9);
            builder.Property(p => p.Descripcion).HasColumnOrder(10);
        }
    }
}
