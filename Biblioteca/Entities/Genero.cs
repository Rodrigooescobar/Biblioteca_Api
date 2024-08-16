using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteca.Entities
{
    public class Genero
    {
        [Key]
        [StringLength(4)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [JsonIgnore]
        public ICollection<Libro> Libros { get; set; } //muchos a muchos, crea auto la tabla
    }
}
