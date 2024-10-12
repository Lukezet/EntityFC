using AutoMapper;
using ServicaDB.DTOs;
using ServicaDB.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ServicaDB.Controllers
{
    [ApiController]
    [Route("api/Profesionales/{prestadorId:int}")]
    public class ProfesionalesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProfesionalesController(ApplicationDbContext context,IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
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
