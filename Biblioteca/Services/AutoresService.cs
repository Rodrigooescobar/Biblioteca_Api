using Biblioteca.Data;
using Biblioteca.Entities;
using Biblioteca.Exceptions;
using Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    // el servicio se encarga de realizar validaciones de negocio
    //y consultar a la db
    public class AutoresService : IAutoresService
    {
        private readonly BibliotecaDbContext _db;
        public AutoresService(BibliotecaDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<Autor>> GetAutores()
        {
            return await _db.Autores
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Autor?> GetAutor(int id)
        {
            return await _db.Autores
                .Include(a => a.Libros) // uso el includo para que me traiga los libros
                .AsNoTracking() // traer el dato pero que no lo meta dentro del trckeo intero
                .FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task UpdateAutor(int id, Autor updateAutor)
        {
            var existe = AutorExists(id);
            if (!existe)
            {
                throw new AutorNotFoundException(id);
            }

            _db.Entry(updateAutor).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        public async Task<Autor> CreateAutor(Autor autor)
        {
            // falta verificar si el genero existe no lo inserto
            _db.Autores.Add(autor);
            await _db.SaveChangesAsync();
            return autor;
        }

        public async Task DeleteAutor(int id)
        {
            var autor = await GetAutor(id);
            if (autor is null)
            {
                throw new AutorNotFoundException(id);
            }

            _db.Autores.Remove(autor);
            await _db.SaveChangesAsync();
        }

        private bool AutorExists(int id)
        {
            return _db.Autores.Any(e => e.Id == id);
        }
    }
}
