using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;

namespace IntroduccionEFCore.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos, dto => 
                dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));
            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
            CreateMap<ComentarioCreacionDTO, Comentario>();

        }
    }
}
