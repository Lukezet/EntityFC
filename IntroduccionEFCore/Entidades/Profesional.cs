using IntroduccionEFCore.Entidades;

namespace ServicaDB.Entidades
{
    public class Profesional
    {
        public int Id  { get; set; }
        public string Nombre { get; set; } = null!;
        public int? IdentificadorNacional { get; set; }
        public long? Telefono { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAnula { get; set; }
        public int PrestadorId { get; set; }//POR CONVENCION AL TENER LA PALABRA Id LUEGO DE LA ENTIDAD Prestador LO TOMA COMO CLAVE FORÁNEA
        public Prestador Prestador { get; set; } = null!;//propiedad de navegacion
                                                         // Relación uno a uno con Usuario
        public Usuario? Usuario { get; set; }

    }
}
