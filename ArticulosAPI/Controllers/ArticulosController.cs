using Microsoft.AspNetCore.Mvc;
using ArticulosAPI.Dtos;
using ArticulosAPI.Servicios.Contratos;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloServicio _articuloServicio;

        // Inyección de dependencias a través del constructor
        public ArticulosController(IArticuloServicio articuloServicio)
        {
            _articuloServicio = articuloServicio;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>> GetArticulos()
        {
            var articulos = await _articuloServicio.ObtenerTodosAsync();
            return Ok(articulos);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDto>> GetArticulo(int id)
        {
            var articulo = await _articuloServicio.ObtenerPorIdAsync(id);
            if (articulo == null)
            {
                return NotFound(new { mensaje = $"No se encontró el artículo con Id {id}" });
            }

            return Ok(articulo);
        }

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<ArticuloDto>> PostArticulo([FromBody] ArticuloDto articuloDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoArticulo = await _articuloServicio.CrearAsync(articuloDto);
            return CreatedAtAction(nameof(GetArticulo), new { id = nuevoArticulo.Id }, nuevoArticulo);
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, [FromBody] ArticuloDto articuloDto)
        {
            if (id != articuloDto.Id)
            {
                return BadRequest(new { mensaje = "El ID del parámetro no coincide con el ID del cuerpo." });
            }

            var actualizado = await _articuloServicio.ActualizarAsync(articuloDto);
            if (!actualizado)
            {
                return NotFound(new { mensaje = $"No se pudo actualizar. No existe el artículo con Id {id}" });
            }

            return NoContent();
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var eliminado = await _articuloServicio.EliminarAsync(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = $"No se pudo eliminar. No existe el artículo con Id {id}" });
            }

            return NoContent();
        }
    }
}