using System.ComponentModel.DataAnnotations;

namespace ServicaDB.DTOs
{
    public class ProfesionalCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
        public int? IdentificadorNacional { get; set; }
        public long? Telefono { get; set; }
        public string? Descripcion { get; set; }
    }
}
