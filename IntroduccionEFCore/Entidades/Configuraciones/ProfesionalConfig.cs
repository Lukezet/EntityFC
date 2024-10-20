using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ServicaDB.Entidades.Configuraciones
{
    public class ProfesionalConfig : IEntityTypeConfiguration<Profesional>
    {
        public void Configure(EntityTypeBuilder<Profesional> builder)
        {
            builder.Property(g => g.FechaCreacion).HasColumnType("datetime");
            builder.Property(g => g.FechaAnula).HasColumnType("datetime");
            builder.Property(g => g.ImgProfesional).HasMaxLength(300);

            builder.Property(p => p.Id).HasColumnOrder(1);
            builder.Property(p => p.Nombre).HasColumnOrder(2);
            builder.Property(p => p.IdentificadorNacional).HasColumnOrder(3);
            builder.Property(p => p.Telefono).HasColumnOrder(4);
            builder.Property(p => p.Descripcion).HasColumnOrder(5);
            builder.Property(p => p.FechaCreacion).HasColumnOrder(6);
            builder.Property(p => p.FechaAnula).HasColumnOrder(7);
        }


    }
}
