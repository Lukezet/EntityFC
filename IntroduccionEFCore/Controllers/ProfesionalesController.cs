using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/Profesionales")]
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
        public async Task<ActionResult> Post(ProfesionalCreacionDTO profesionalCreacionDTO) 
        {
            var profesional = mapper.Map<Profesional>(profesionalCreacionDTO);
            context.Add(profesional);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
