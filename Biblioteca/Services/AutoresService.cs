using Biblioteca.Entities;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Biblioteca.Services
{
    // el servicio se encarga de realizar validaciones de negocio
    //y consultar a la db
    public class AutoresService
    {
        private readonly BibliotecaDbContext _db;
        public AutoresService(BibliotecaDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<Autor>> GetAutores()
        {
            return await _db.Autores.ToListAsync();
        }

        public async Task<Autor?> GetAutor(int id)
        {
            return await _db.Autores.FindAsync(id);
        }

        public async Task UpdateAutor(int id, Autor updateAutor)
        {
            var existe = AutorExists(id);
            if (!existe)
            {
                throw new Exception($"No existe autor con id {id}");
            }

            _db.Entry(updateAutor).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        public async Task<Autor> CreateAutor(Autor autor)
        {
            _db.Autores.Add(autor);
            await _db.SaveChangesAsync();
            return autor;
        }

        public async Task DeleteAutor(int id)
        {
            var autor = await GetAutor(id);
            if (autor is null)
            {
                throw new Exception($"No existe autor con id {id}");
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
