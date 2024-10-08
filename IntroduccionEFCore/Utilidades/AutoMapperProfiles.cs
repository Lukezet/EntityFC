using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;

namespace IntroduccionEFCore.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ServicioCreacionDTO, Servicio>();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Servicios, dto => 
                dto.MapFrom(campo => campo.Servicios.Select(id => new Servicio { Id = id })));
            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
            CreateMap<ComentarioCreacionDTO, Comentario>();

        }
    }
}
