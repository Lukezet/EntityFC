using AutoMapper;
using ServicaDB.DTOs;
using ServicaDB.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IntroduccionEFCore.DTOs;
using AutoMapper.QueryableExtensions;

namespace ServicaDB.Controllers
{
    [ApiController]
    [Route("api/Profesionales")]
    public class ProfesionalesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProfesionalesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesional>>> Get()
        {
            return await context.Profesionales.ToListAsync();
        }

        [HttpGet("PorPrestador/{prestadorId:int}")]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetPorPrestador(int prestadorId)
        {
            var profesionales = await context.Profesionales
                                              .Where(p => p.PrestadorId == prestadorId)
                                              .ToListAsync();
            if (profesionales == null || profesionales.Count == 0)
            {
                return NotFound();
            }

            return Ok(profesionales);
        }
        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Profesional>>> Get(string nombre)
        {
            //version 1
            return await context.Profesionales.Where(a => a.Nombre == nombre).ToListAsync();

        }

        [HttpGet("nombre/v2")]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetV2(string nombre)
        {
            //version 2:Contiene
            return await context.Profesionales.Where(a => a.Nombre.Contains(nombre)).ToListAsync();

        }

        [HttpGet("FechaCrea/Rango")]
        public async Task<ActionResult<IEnumerable<Profesional>>> Get(DateTime inicio, DateTime fin) 
        {
            return await context.Profesionales.Where(a => a.FechaCreacion>= inicio && a.FechaCreacion<=fin).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesional>> Get(int id) 
        {
            var profesional = await context.Profesionales.FirstOrDefaultAsync(a=> a.Id == id);
            if (profesional is null) 
            {
                return NotFound();
            }
            return profesional;
        }


        [HttpGet("IdyNombre")]
        public async Task<ActionResult<IEnumerable<ProfesionalDTO>>> GetIdyNombre()
        {
            //Mapeo manual sin automapper
            //return await context.Profesionales.Select(a => new ProfesionalDTO { Id= a.Id, Nombre= a.Nombre }).ToListAsync();

            //Con AUTOMAPPER
            return await context.Profesionales.ProjectTo<ProfesionalDTO>(mapper.ConfigurationProvider).ToListAsync();

        }

        [HttpPost("{prestadorId:int}")]
        public async Task<ActionResult> Post(int prestadorId, ProfesionalCreacionDTO profesionalCreacionDTO)
        {
            try
            {
                var profesional = mapper.Map<Profesional>(profesionalCreacionDTO);
                profesional.PrestadorId = prestadorId;
                profesional.FechaCreacion = DateTime.Now;
                context.Add(profesional);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                // Registrar el error o manejarlo adecuadamente
                return StatusCode(500, $"Error al crear profesional: {ex.Message}");
            }
        }
    }
}
