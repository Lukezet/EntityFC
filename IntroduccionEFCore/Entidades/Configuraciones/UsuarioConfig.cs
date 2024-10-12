using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            // Configuración de las propiedades
            builder.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Correo).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Contraseña).IsRequired();

            // Configuración de la relación uno a uno con Profesional
            builder.HasOne(u => u.Profesional)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.ProfesionalId)
                .OnDelete(DeleteBehavior.Cascade); // Opcional: define el comportamiento al eliminar
        }
    }
}
