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
            CreateMap<ProfesionalCreacionDTO, Profesional>();
            CreateMap<PrestadorCreacionDTO, Prestador>()
                .ForMember(ent => ent.Servicios, dto => 
                dto.MapFrom(campo => campo.Servicios.Select(id => new Servicio { Id = id })));
            CreateMap<PrestadorProfesionalCreacionDTO, PrestadorProfesional>();
            CreateMap<ComentarioCreacionDTO, Comentario>();

        }
    }
}
