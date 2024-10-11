using Microsoft.EntityFrameworkCore;

namespace ServicaDB.Entidades.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelbuilder) 
        {
            var RobertDeNiro = new Profesional() 
            { 
                Id = 2, 
                Nombre = "Robert de Niro", 
                FechaNacimiento = new DateTime(1943, 8, 17), 
                Fortuna = 70000000 
            };
            var SamuelLJackson = new Profesional()
            {
                Id = 3,
                Nombre = "Samuel L. Jackson",
                FechaNacimiento = new DateTime(1948, 12, 21),
                Fortuna = 12000000
            };
            modelbuilder.Entity<Profesional>().HasData(RobertDeNiro);
        }
    }
}
