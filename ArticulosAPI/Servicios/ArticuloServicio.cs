using AutoMapper;
using ArticulosAPI.Dtos;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorios.Contratos;
using ArticulosAPI.Servicios.Contratos;

namespace ArticulosAPI.Servicios
{
    public class ArticuloServicio : IArticuloServicio
    {
        private readonly IArticuloRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ArticuloServicio(IArticuloRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticuloDto>> ObtenerTodosAsync()
        {
            var articulos = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
        }

        public async Task<ArticuloDto?> ObtenerPorIdAsync(int id)
        {
            var articulo = await _repositorio.ObtenerPorIdAsync(id);
            if (articulo == null)
            {
                return null;
            }

            return _mapper.Map<ArticuloDto>(articulo);
        }

        public async Task<ArticuloDto> CrearAsync(ArticuloDto articuloDto)
        {
            var entidad = _mapper.Map<Articulo>(articuloDto);
            var nuevoArticulo = await _repositorio.CrearAsync(entidad);
            return _mapper.Map<ArticuloDto>(nuevoArticulo);
        }

        public async Task<bool> ActualizarAsync(ArticuloDto articuloDto)
        {
            var entidad = _mapper.Map<Articulo>(articuloDto);
            return await _repositorio.ActualizarAsync(entidad);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repositorio.EliminarAsync(id);
        }
    }
}