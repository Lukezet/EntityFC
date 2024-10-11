using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ServicaDB.Entidades
{
    public class Servicio
    {
        //[Key] ANOTACION DE DATOS
        public int Id { get; set; }
        //[StringLength(maximumLength:150)] //otro Ejemplo de Anotacion de datos
        public string Nombre { get; set; } = null!;

        public HashSet<Prestador> Prestadores { get; set; } = new HashSet<Prestador>();
    }
}
//por convencion si se usa Id se tomará como primary key 
//si NO se usa Id como IdServicio se deberá aclarar a travez de alguna de estas dos opciones:

//1 - anotacion de datos: [Key]  
//2 - Api fluente : conjunto de metodos que podemos utilizar para configurar las propiedades y relaciones de entity core fuera de la entidad ¿DONDE?:
// en el ApplicationDbContext