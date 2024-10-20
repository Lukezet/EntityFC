using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ServicaDB.Entidades.Configuraciones
{
    public class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            //var cienciaFiccion = new Servicio { Id = 5, Nombre = "Ciencia Ficcion" };
            //var animacion = new Servicio { Id = 6, Nombre = "Animacion" };
            //builder.HasData(cienciaFiccion, animacion);

            builder.Property(g => g.Logo).HasMaxLength(500);
            builder.HasIndex(p => p.Nombre).IsUnique();
            var Limpieza = new Servicio() { Id = 9, Nombre = "Limpieza" ,Logo="./src/assets/mop.png"};
            var Jardineria = new Servicio() { Id = 10, Nombre = "Jardinería", Logo = "./src/assets/gardener.png" };
            var Carpinteria = new Servicio() { Id = 11, Nombre = "Carpintería", Logo = "./src/assets/carpenter.png" };
            var Pintura = new Servicio() { Id = 12, Nombre = "Pintura", Logo = "./src/assets/paint-roller.png" };
            var Albanileria = new Servicio() { Id = 13, Nombre = "Albañilería", Logo = "./src/assets/bricklayer.png" };
            var Cerrajeria = new Servicio() { Id = 14, Nombre = "Cerrajería", Logo = "./src/assets/locksmith.png" };
            var ReparacionElectrodomesticos = new Servicio() { Id = 15, Nombre = "Reparación de Electrodomésticos", Logo = "./src/assets/appliance-repair.png" };
            var Niñeras = new Servicio() { Id = 16, Nombre = "Niñeras", Logo = "./src/assets/nanny.png" };
            var InstalacionSeguridad = new Servicio() { Id = 17, Nombre = "Alarmas y Seguridad", Logo = "./src/assets/insurance.png" };
            var Veterinaria = new Servicio() { Id = 18, Nombre = "Veterinaria", Logo = "./src/assets/vet.png" };
            var Mudanzas = new Servicio() { Id = 19, Nombre = "Mudanzas", Logo = "./src/assets/moving-truck.png" };

            builder.HasData(Limpieza);
            builder.HasData(Jardineria);
            builder.HasData(Carpinteria);
            builder.HasData(Pintura); 
            builder.HasData(Albanileria);
            builder.HasData(Cerrajeria);
            builder.HasData(ReparacionElectrodomesticos);
            builder.HasData(Niñeras);
            builder.HasData(InstalacionSeguridad);
            builder.HasData(Veterinaria);
            builder.HasData(Mudanzas);



        }
    }
}
