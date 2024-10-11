using ServicaDB.Entidades;

namespace ServicaDB.DTOs
{
    public class PrestadorCreacionDTO
    {
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Servicios { get; set; } = new List<int>();//hacemos una lista de int ya que sera la lista de ids de servicio
        public List<PrestadorProfesionalCreacionDTO> PrestadoresProfesionales { get; set; } = new List<PrestadorProfesionalCreacionDTO>();
                
    }
}
