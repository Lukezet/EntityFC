using System.ComponentModel.DataAnnotations;

namespace IntroduccionEFCore.DTOs
{
    public class ServicioCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
    }
}
