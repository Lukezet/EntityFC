namespace ServicaDB.Entidades
{
    public class Prestador
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Servicio> Servicios { get; set; } = new HashSet<Servicio>();//Nos saltamos la entidad intermedia y conectamos directo a Servicio
        public List<PrestadorProfesional> PrestadoresProfesionales { get; set; } = new List<PrestadorProfesional>();//haciendo uso de la entidad intermedia 
                                                                                              //NO NOS CONECTAMOS DIRECTO A Profesional SINO A SU ENTIDAD INTERMEDIA PrestadorsProfesionales

    }
}
