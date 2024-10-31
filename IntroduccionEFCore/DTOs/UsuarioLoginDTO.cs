using ServicaDB.Entidades;

namespace IntroduccionEFCore.DTOs
{
    public class UsuarioLoginDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAnula { get; set; }
        public int? ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }
    }

}
