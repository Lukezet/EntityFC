using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServicaDB.Entidades.Configuraciones
{
    public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.Property(g => g.Contenido).HasMaxLength(300);
            builder.Property(g => g.Calificacion)
                   .HasColumnType("decimal(2,1)");
            builder.Property(g => g.FechaCrea).HasColumnType("datetime");
            builder.Property(g => g.FechaAnula).HasColumnType("datetime");
        }
    }
}
