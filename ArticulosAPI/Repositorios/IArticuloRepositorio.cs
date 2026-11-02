using ArticulosAPI.Modelos;

namespace ArticulosAPI.Repositorios.Contratos
{
    public interface IArticuloRepositorio
    {
        Task<IEnumerable<Articulo>> ObtenerTodosAsync();
        Task<Articulo?> ObtenerPorIdAsync(int id);
        Task<Articulo> CrearAsync(Articulo articulo);
        Task<bool> ActualizarAsync(Articulo articulo);
        Task<bool> EliminarAsync(int id);
    }
}