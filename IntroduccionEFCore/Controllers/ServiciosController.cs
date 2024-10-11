using AutoMapper;
using ServicaDB.DTOs;
using ServicaDB.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ServicaDB.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    public class ServiciosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServiciosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ServicioCreacionDTO servicioCreacion) 
        {
            //var servicio = new Servicio //Esto comentado es la forma de mappear manual
            //{
            //    Nombre = servicioCreacion.Nombre,
            //};
            var servicio = mapper.Map<Servicio>(servicioCreacion);
            context.Add(servicio);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(ServicioCreacionDTO[] serviciosCreacionDTO)
        {
            var servicios = mapper.Map<Servicio[]>(serviciosCreacionDTO);
            context.AddRange(servicios);
            await context.SaveChangesAsync();
            return Ok();

        }

    }
}
