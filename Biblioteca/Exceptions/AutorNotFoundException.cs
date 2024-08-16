namespace Biblioteca.Exceptions
{
    public class AutorNotFoundException : Exception
    {
        public AutorNotFoundException(int id): base($"No existe el autor con ese id: {id}")
        {
        }
    }
}
