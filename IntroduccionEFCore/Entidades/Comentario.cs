namespace IntroduccionEFCore.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Contenido { get; set; } = null!;
        public bool Recomendar { get; set; }

        public int PeliculaId { get;set; }//POR CONVENCION AL TENER LA PALABRA Id LUEGO DE LA ENTIDAD PELICULA LO TOMA COMO CLAVE FORÁNEA
        public Pelicula Pelicula { get; set; } = null!;//propiedad de navegacion
                

    }
}
