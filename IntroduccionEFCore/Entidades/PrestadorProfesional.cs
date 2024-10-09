namespace IntroduccionEFCore.Entidades
{
    public class PrestadorProfesional
    {
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; } = null!;

        public int ProfesionalId { get; set; }
        public Profesional Profesional { get; set; } = null!;
        public string Personaje { get; set; } = null!;
        public int Orden { get; set; }
    }
}
