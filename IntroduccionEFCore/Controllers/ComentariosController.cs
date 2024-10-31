using AutoMapper;
using ServicaDB.DTOs;
using ServicaDB.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ServicaDB.Controllers
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
[Authorize]
[HttpPost]
public async Task<ActionResult> Post(int prestadorId, ComentarioCreacionDTO comentarioCreacionDTO)
{
    var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
    
    // Asigna el prestador
    comentario.PrestadorId = prestadorId;

            // Obtén el UsuarioId del contexto de la autenticación (si usas JWT o Identity)
            var usuarioId = int.Parse(User.FindFirst("UsuarioId").Value);
            comentario.UsuarioId = usuarioId;

     comentario.FechaCrea = DateTime.Now;
     context.Add(comentario);
    await context.SaveChangesAsync();
    return Ok();
}
        
    }
}
