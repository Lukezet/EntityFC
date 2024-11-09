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
        private readonly IConfiguration configuration;


        public PrestadoresController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestador>>> Get()
        {
            return await context.Prestadores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> Get(int id)
{
        var prestador = await context.Prestadores
        .Include(p => p.Comentarios)
        .Include(p => p.Servicios)
        .Include(p => p.Profesionales)
        .FirstOrDefaultAsync(p => p.Id == id);

        if (prestador == null) return NotFound();

            // Calcular el promedio de calificación de los comentarios
            var promedioCalificacion = prestador.Comentarios.Any()
                ? Math.Round(prestador.Comentarios.Average(c => c.Calificacion), 1)
                : 0;

            // Devolver el prestador y el promedio de calificación en un nuevo objeto anónimo
            return Ok(new
            {
              Prestador = prestador,
              PromedioCalificacion = promedioCalificacion
            });
        }
        [HttpGet("select/{id:int}")]
        public async Task<ActionResult<Prestador>> GetSelect(int id)
        {
            var prestador = await context.Prestadores
                .Select(pres => new
                {
                    pres.Id,
                    pres.Nombre,
                    Servicios = pres.Servicios.Select(g => g.Nombre).ToList(),
                    Profesionales = pres.Profesionales.Select(pro =>
                    new
                    {
                        pro.Id,
                        pro.Nombre,
                        pro.Telefono,

                    }),
                    CantidadComentarios = pres.Comentarios.Count()

                })
                .FirstOrDefaultAsync(p => p.Id == id);

            return prestador == null ? NotFound() : Ok(prestador);

        }

        [HttpGet("porServicio/{servicioId:int}")]
        public async Task<ActionResult<IEnumerable<Prestador>>> GetPorServicio(int servicioId)
        {
            // Filtramos prestadores que tengan el servicioId en su lista de Servicios
            var prestadores = await context.Prestadores
                                           .Where(p => p.Servicios.Any(s => s.Id == servicioId))
                                           .Include(p => p.Servicios)
                                           .Include(p => p.Profesionales)
                                           .Select(p => new
                                           {
                                               p.Id,
                                               p.Nombre,
                                               p.Eslogan,
                                               p.Telefono,
                                               p.Direccion,
                                               p.ImgPrestador,
                                               // Calcula el promedio de calificaciones
                                               PromedioCalificacion = p.Comentarios.Any() ? p.Comentarios.Average(c => c.Calificacion) : (decimal?)null,
                                               Servicios = p.Servicios.Select(s => new
                                               {
                                                   s.Id,
                                                   s.Nombre,
                                                   s.Logo
                                               }).ToList(),
                                               Profesionales = p.Profesionales.Select(pro => new
                                               {
                                                   pro.Id,
                                                   pro.Nombre,
                                                   pro.Telefono,
                                                   pro.Descripcion,
                                                   pro.ImgProfesional
                                               }).ToList()
                                           })
                                           .ToListAsync();

            if (prestadores == null || prestadores.Count == 0)
            {
                return NotFound();
            }

            return Ok(prestadores);
        }
        [HttpPost("varios")]
        public async Task<ActionResult> Post(PrestadorCreacionDTO[] prestadoresCreacionDTO)
        {
            var prestadores = mapper.Map<Prestador[]>(prestadoresCreacionDTO);
            context.AddRange(prestadores);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPost]
        public async Task<ActionResult> Post(PrestadorCreacionDTO prestadorCreacionDTO)
        {

            var prestador = mapper.Map<Prestador>(prestadorCreacionDTO);

          if (prestadorCreacionDTO.ImgPrestador != null)
            {
                var imgPrestadorPath = Path.Combine("C:\\Users\\Lucas\\Desktop\\VueApp\\ServicaVue\\public\\PrestadorImg", Guid.NewGuid().ToString() + Path.GetExtension(prestadorCreacionDTO.ImgPrestador.FileName));
                using (var stream = new FileStream(imgPrestadorPath, FileMode.Create))
                {
                    await prestadorCreacionDTO.ImgPrestador.CopyToAsync(stream);
                }
                prestador.ImgPrestador = imgPrestadorPath;
            }

            if (prestadorCreacionDTO.PortadaImg != null)
            {
                
                var portadaImgPath = Path.Combine("C:\\Users\\Lucas\\Desktop\\VueApp\\ServicaVue\\public\\Portadas", Guid.NewGuid().ToString() + Path.GetExtension(prestadorCreacionDTO.PortadaImg.FileName));
                using (var stream = new FileStream(portadaImgPath, FileMode.Create))
                {
                    await prestadorCreacionDTO.PortadaImg.CopyToAsync(stream);
                }
                prestador.PortadaImg = portadaImgPath;
            }
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


        [HttpDelete("{id:int}/formaModerna")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAlteradas = await context.Prestadores.Where(s => s.Id == id).ExecuteDeleteAsync();
            if (filasAlteradas == 0)
            {
                return NotFound();
            }
            return NoContent();

        }

    }   
}
