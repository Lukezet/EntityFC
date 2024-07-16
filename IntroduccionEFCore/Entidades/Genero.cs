using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IntroduccionEFCore.Entidades
{
    public class Genero
    {
        //[Key] ANOTACION DE DATOS
        public int Id { get; set; }
        //[StringLength(maximumLength:150)] //otro Ejemplo de Anotacion de datos
        public string Nombre { get; set; } = null!;

        public HashSet<Pelicula> Peliculas { get; set; } = new HashSet<Pelicula>();
    }
}
//por convencion si se usa Id se tomará como primary key 
//si NO se usa Id como IdGenero se deberá aclarar a travez de alguna de estas dos opciones:

//1 - anotacion de datos: [Key]  
//2 - Api fluente : conjunto de metodos que podemos utilizar para configurar las propiedades y relaciones de entity core fuera de la entidad ¿DONDE?:
// en el ApplicationDbContext