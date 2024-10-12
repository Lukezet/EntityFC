using ServicaDB.Entidades;

namespace IntroduccionEFCore.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAnula { get; set; }

        // Relación uno a uno con Profesional
        public int? ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }
    }
}
