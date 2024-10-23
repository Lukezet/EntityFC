using IntroduccionEFCore.Entidades;

namespace ServicaDB.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Contenido { get; set; } = null!;
        public int Calificacion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaAnula { get; set; }
        public int PrestadorId { get;set; }//POR CONVENCION AL TENER LA PALABRA Id LUEGO DE LA ENTIDAD Prestador LO TOMA COMO CLAVE FORÁNEA
        public Prestador Prestador { get; set; } = null!;//propiedad de navegacion
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

    }
}
