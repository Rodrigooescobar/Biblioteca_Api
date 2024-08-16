using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        // muchos libros por autor
        public ICollection<Libro> Libros { get; set; }

    }
}
