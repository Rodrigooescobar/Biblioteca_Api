using Biblioteca.Entities;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTOs
{
    // objeto de transferencia de datos
    // objetos para tramitir solo los datos necesarios y ocultar otros
    public class AutorDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        // muchos libros por autor
        public List<LibroDTO> Libros { get; set; }
    }

    public record class LibroDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public DateOnly? FechaPublicacion { get; set; }
      
        public List<GeneroDTO> Genero { get; set; }
    }

    public record class GeneroDTO
    {
        [StringLength(4,ErrorMessage = "El codigo debe tener exactamente 4 caracteres")]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }

    public static class Mapper
    {
        public static Autor ToAutor(this AutorDTO autorDTO)
        {
            return new Autor
            {
                Nombre = autorDTO.Nombre,
                FechaNacimiento = autorDTO.FechaNacimiento,
                Libros = autorDTO.Libros.Select(l => l.ToLibro()).ToList()
            };
        }

        public static Libro ToLibro(this LibroDTO dto)
        {
            return new Libro
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaPublicacion = dto.FechaPublicacion,
                Genero = dto.Genero.Select(g => g.ToGenero()).ToList()
            };
        }

        public static Genero ToGenero(this GeneroDTO dto)
        {
            return new Genero
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre
            };
        }
    }
}
