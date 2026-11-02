using AutoMapper;
using ArticulosAPI.Dtos;
using ArticulosAPI.Modelos;

namespace ArticulosAPI
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            // Mapeo bidireccional entre la entidad Articulo y ArticuloDto
            CreateMap<Articulo, ArticuloDto>().ReverseMap();
        }
    }
}