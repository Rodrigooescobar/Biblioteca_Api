using Biblioteca.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Biblioteca.Data
{
    public class BibliotecaDbContext : DbContext
    {
        // DbSet<T> es una colección de entidades de un tipo específico
        public DbSet<Autor> Autores => Set<Autor>();
        // nueva tabla libros
        public DbSet<Libro> Libros => Set<Libro>();

        public DbSet<Genero> Generos => Set<Genero>();
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> optiones) : base(optiones)
        {
        }
    }
}
