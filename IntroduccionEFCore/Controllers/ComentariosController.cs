using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/prestadores/{prestadorId:int}/comentarios")]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ComentariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int prestadorId,
            ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PrestadorId = prestadorId;
            context.Add(comentario);
            await context.SaveChangesAsync();
            return Ok();

        }
        
    }
}
