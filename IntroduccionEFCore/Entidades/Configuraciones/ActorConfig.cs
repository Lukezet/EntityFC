using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(g => g.FechaNacimiento).HasColumnType("datetime");
            builder.Property(g => g.Fortuna).HasPrecision(18, 2);
        }
    }
}
