using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorios.Contratos;

namespace ArticulosAPI.Repositorios
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Articulo>> ObtenerTodosAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task<Articulo> CrearAsync(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }

        public async Task<bool> ActualizarAsync(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return false;
            }

            _context.Articulos.Remove(articulo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}