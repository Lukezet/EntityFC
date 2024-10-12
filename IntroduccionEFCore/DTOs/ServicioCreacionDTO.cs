using System.ComponentModel.DataAnnotations;

namespace ServicaDB.DTOs
{
    public class ServicioCreacionDTO
    {
        public string Nombre { get; set; } = null!;
        public string? Logo { get; set; }
    }
}
