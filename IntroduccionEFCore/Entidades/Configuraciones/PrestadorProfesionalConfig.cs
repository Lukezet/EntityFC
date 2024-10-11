using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServicaDB.Entidades.Configuraciones
{
    public class PrestadorProfesionalConfig : IEntityTypeConfiguration<PrestadorProfesional>
    {
        public void Configure(EntityTypeBuilder<PrestadorProfesional> builder)
        {
            builder.HasKey(pa => new { pa.ProfesionalId, pa.PrestadorId });
        }
    }
}
