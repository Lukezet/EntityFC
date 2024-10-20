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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> Get()
        {
            return await context.Servicios.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post(ServicioCreacionDTO servicioCreacion)
        {
            //var servicio = new Servicio //Esto comentado es la forma de mappear manual
            //{
            //    Nombre = servicioCreacion.Nombre,
            //};
            var yaExiste = await context.Servicios.AnyAsync(s=>
            s.Nombre==servicioCreacion.Nombre);

            if (yaExiste) 
            { 
                return BadRequest("Ya existe un servicio con el nombre " + servicioCreacion.Nombre); 
            }
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

        [HttpPut("{id:int}/nombre2")]//MODELO PUT CONECTADO
        public async Task<ActionResult> Put(int id)
        {
            var servicio = await context.Servicios.FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null)
            {
                return NotFound();
            }

            servicio.Nombre = servicio.Nombre + 2;

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]//MODELO PUT DESCONECTADO
        public async Task<ActionResult> Put(int id, ServicioCreacionDTO servicioCreacionDTO)
        {
            var servicio = mapper.Map<Servicio>(servicioCreacionDTO);
            servicio.Id = id;
            context.Update(servicio);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}/formaModerna")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAlteradas = await context.Servicios.Where(s => s.Id == id).ExecuteDeleteAsync();
            if (filasAlteradas == 0)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpDelete("{id:int}/formaAnterior")]
        public async Task<ActionResult> DeleteAnterior(int id)
        {
            var servicio = await context.Servicios.FirstOrDefaultAsync(s => s.Id == id);
            if (servicio is null)
            {
                return NotFound();
            }
            context.Remove(servicio);
            await context.SaveChangesAsync();
            return NoContent();

        }


    }
}
