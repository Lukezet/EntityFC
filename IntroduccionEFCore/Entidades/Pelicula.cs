namespace IntroduccionEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();//Nos saltamos la entidad intermedia y conectamos directo a Genero
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();//haciendo uso de la entidad intermedia 
                                                                                              //NO NOS CONECTAMOS DIRECTO A ACTOR SINO A SU ENTIDAD INTERMEDIA PeliculasActores

    }
}
