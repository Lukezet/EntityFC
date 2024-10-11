namespace ServicaDB.Entidades
{
    public class Profesional
    {
        public int Id  { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<PrestadorProfesional> PrestadoresProfesionales { get; set; } = new List<PrestadorProfesional>();

    }
}
