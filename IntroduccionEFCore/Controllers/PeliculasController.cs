using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO) 
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);
            if (pelicula.Servicios is not null) 
            {
                foreach (var servicio in pelicula.Servicios) 
                {
                    context.Entry(servicio).State = EntityState.Unchanged;//ESTO HAY QUE HACERLO porq estamos utilizando la configuracion de muchos a
                                                                        //muchos saltandnos la parte de control de la tabla intermedia
                }
            }

            if (pelicula.PeliculasActores is not null) 
            { 
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++) 
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }

            }
            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
        }

    }   
}
