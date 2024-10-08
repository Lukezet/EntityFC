namespace IntroduccionEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Servicio> Servicios { get; set; } = new HashSet<Servicio>();//Nos saltamos la entidad intermedia y conectamos directo a Servicio
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();//haciendo uso de la entidad intermedia 
                                                                                              //NO NOS CONECTAMOS DIRECTO A ACTOR SINO A SU ENTIDAD INTERMEDIA PeliculasActores

    }
}
