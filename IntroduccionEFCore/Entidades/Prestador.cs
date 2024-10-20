namespace ServicaDB.Entidades
{
    public class Prestador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Eslogan { get; set; }
        public long Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaAnula { get; set; }
        public string Provincia { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string? ImgPrestador { get; set; }
        public string? PortadaImg { get; set; }
        public string? Descripcion { get; set; }
        public HashSet<Profesional> Profesionales { get; set; } = new HashSet<Profesional>();
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Servicio> Servicios { get; set; } = new HashSet<Servicio>();//Nos saltamos la entidad intermedia y conectamos directo a Servicio
        

    }
}
