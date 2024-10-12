using AutoMapper;
using ServicaDB.DTOs;
using ServicaDB.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;

namespace ServicaDB.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UsuarioCreacionDTO usuarioCreacionDTO)
        {
            // Mapeo del DTO a la entidad Usuario
            var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);
            usuario.FechaCreacion = DateTime.Now; // Asignar la fecha de creación

            context.Add(usuario); // Agregar el nuevo usuario al contexto
            await context.SaveChangesAsync(); // Guardar los cambios en la base de datos

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario); // Retornar el usuario creado
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario; // Retornar el usuario encontrado
        }

    }
}
