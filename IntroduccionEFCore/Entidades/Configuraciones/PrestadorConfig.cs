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
            builder.Property(g => g.ImgPrestador).HasMaxLength(300);
            builder.Property(g => g.PortadaImg).HasMaxLength(300);

        }
    }
}
