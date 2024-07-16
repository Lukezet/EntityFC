using IntroduccionEFCore.Entidades;

namespace IntroduccionEFCore.DTOs
{
    public class PeliculaCreacionDTO
    {
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Generos { get; set; } = new List<int>();//hacemos una lista de int ya que sera la lista de ids de genero
        public List<PeliculaActorCreacionDTO> PeliculasActores { get; set; } = new List<PeliculaActorCreacionDTO>();
                
    }
}
