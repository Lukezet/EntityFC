using System.ComponentModel.DataAnnotations;

namespace ServicaDB.DTOs
{
    public class ServicioCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
    }
}
