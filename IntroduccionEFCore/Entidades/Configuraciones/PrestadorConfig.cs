using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class PrestadorConfig : IEntityTypeConfiguration<Prestador>
    {
        public void Configure(EntityTypeBuilder<Prestador> builder)
        {
            builder.Property(g => g.FechaEstreno).HasColumnType("datetime");
        }
    }
}
