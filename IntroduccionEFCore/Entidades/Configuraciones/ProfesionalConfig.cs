using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class ProfesionalConfig : IEntityTypeConfiguration<Profesional>
    {
        public void Configure(EntityTypeBuilder<Profesional> builder)
        {
            builder.Property(g => g.FechaNacimiento).HasColumnType("datetime");
            builder.Property(g => g.Fortuna).HasPrecision(18, 2);
        }
    }
}
