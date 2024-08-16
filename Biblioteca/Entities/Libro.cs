using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteca.Entities
{
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public DateOnly? FechaPublicacion { get; set; }
        [JsonIgnore] // evitar bucle infinito
        public Autor Autor { get; set; }

        public ICollection<Genero> Genero { get; set; } // muchos a muchos, crea auto. la tabla

    }
}
