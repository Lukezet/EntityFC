using ServicaDB.Entidades;

namespace ServicaDB.DTOs
{
    public class PrestadorCreacionDTO
    {
        public string Nombre { get; set; } = null!;
        public string? Eslogan { get; set; }
        public long Telefono { get; set; }
        public string? Direccion { get; set; }
        public string Provincia { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string? Descripcion { get; set; }
        public List<int> Servicios { get; set; } = new List<int>();//hacemos una lista de int ya que sera la lista de ids de servicio

        public IFormFile? ImgPrestador { get; set; }
        public IFormFile? PortadaImg { get; set; }

    }
}
