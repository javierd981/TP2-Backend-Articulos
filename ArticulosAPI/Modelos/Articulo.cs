using System.ComponentModel.DataAnnotations;

namespace ArticulosAPI.Modelos
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty; // <-- Agregada
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
