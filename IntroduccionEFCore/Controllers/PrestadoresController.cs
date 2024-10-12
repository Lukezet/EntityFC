using AutoMapper;
using ServicaDB.DTOs;
using ServicaDB.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ServicaDB.Controllers
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
            prestador.FechaCrea = DateTime.Now;
            context.Add(prestador);
            await context.SaveChangesAsync();
            return Ok();
        }

    }   
}
