using ArticulosAPI.Dtos;

namespace ArticulosAPI.Servicios.Contratos
{
    public interface IArticuloServicio
    {
        Task<IEnumerable<ArticuloDto>> ObtenerTodosAsync();
        Task<ArticuloDto?> ObtenerPorIdAsync(int id);
        Task<ArticuloDto> CrearAsync(ArticuloDto articuloDto);
        Task<bool> ActualizarAsync(ArticuloDto articuloDto);
        Task<bool> EliminarAsync(int id);
    }
}