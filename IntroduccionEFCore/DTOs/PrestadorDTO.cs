using ServicaDB.Entidades;

namespace ServicaDB.DTOs
{
    public class PrestadorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Eslogan { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaAnula { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string ImgPrestador { get; set; }
        public string PortadaImg { get; set; }
        public string Descripcion { get; set; }
        public double? PromedioCalificacion { get; set; }
        public List<Servicio> Servicios { get; set; }
        public List<Profesional> Profesionales { get; set; }
    }
}
