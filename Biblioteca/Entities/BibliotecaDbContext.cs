using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Biblioteca.Entities
{
    public class BibliotecaDbContext : DbContext
    {
        // DbSet<T> es una colección de entidades de un tipo específico
        public DbSet<Autor> Autores => Set<Autor>();
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> optiones): base(optiones)
        {
        }
    }
}
