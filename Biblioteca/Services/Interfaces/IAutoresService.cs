using Biblioteca.Entities;

namespace Biblioteca.Services.Interfaces
{
    public interface IAutoresService
    {
        Task<Autor> CreateAutor(Autor autor);
        Task DeleteAutor(int id);
        Task<Autor?> GetAutor(int id);
        Task<List<Autor>> GetAutores();
        Task UpdateAutor(int id, Autor updateAutor);
    }
}
