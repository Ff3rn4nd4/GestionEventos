using AutoMapper;
using GestionEventos.DTOs;
using GestionEventos.Entidades;

namespace GestionEventos.Utilidades
{
    public class MappingP: Profile
    {
        public MappingP() 
        {
            //Este mapeo queda distinto ya que esta relacionado a estas entidades
            CreateMap<Evento, EventoDto>();
            CreateMap<CrearEventoDto,Evento>();
            /*CreateMap<Evento, EventoDto>()
            .ForMember(dest => dest.ConteoCapacidad, opt => opt.MapFrom(src => src.Asistencias.Count));*/
            CreateMap<AsistenciaDto, Asistencia>();
            /*CreateMap<Asistencia, AsistenciaDto>()
            .ForMember(dest => dest.Evento, opt => opt.MapFrom(src => src.Evento));*/
            CreateMap<ComentarioDto, Comentario>();
            CreateMap<PromocionDto, Promocion>();
            CreateMap<PromocionPatchDto, Promocion>();
            CreateMap<Promocion, PromocionPatchDto>();
            CreateMap<FavoritoDto, Favorito>();
        }
    }
}
