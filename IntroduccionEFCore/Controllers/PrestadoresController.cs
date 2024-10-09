using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/prestadores")]
    public class PrestadoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PrestadoresController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(PrestadorCreacionDTO prestadorCreacionDTO) 
        {
            var prestador = mapper.Map<Prestador>(prestadorCreacionDTO);
            if (prestador.Servicios is not null) 
            {
                foreach (var servicio in prestador.Servicios) 
                {
                    context.Entry(servicio).State = EntityState.Unchanged;//ESTO HAY QUE HACERLO porq estamos utilizando la configuracion de muchos a
                                                                        //muchos saltandnos la parte de control de la tabla intermedia
                }
            }

            if (prestador.PrestadoresProfesionales is not null) 
            { 
                for (int i = 0; i < prestador.PrestadoresProfesionales.Count; i++) 
                {
                    prestador.PrestadoresProfesionales[i].Orden = i + 1;
                }

            }
            context.Add(prestador);
            await context.SaveChangesAsync();
            return Ok();
        }

    }   
}
