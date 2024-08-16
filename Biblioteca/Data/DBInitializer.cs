using Biblioteca.Entities;

namespace Biblioteca.Data
{
    // iniciador de base de datos
    public class DBInitializer
    {
        public static void Initialize(BibliotecaDbContext context)
        {
            if (context.Libros.Any() && context.Autores.Any() && context.Generos.Any())
            {
                return;
            }

            var terror = new Genero { Codigo = "TERR", Nombre = "Terror" };
            var fantasia = new Genero { Codigo = "FANT", Nombre = "Fantasia" };
            var policial = new Genero { Codigo = "POLI", Nombre = "Policial" };

            var autores = new Autor[]
            {
                new()
                {
                    Nombre = "Stephen King",
                    FechaNacimiento = new DateTime(1950,01,01),
                    Libros = [
                        new (){
                            Nombre = "Carrie",
                            Descripcion = "El primer libro de SK",
                            Genero = [terror]
                        },
                         new (){
                            Nombre = "Los Ojos del Dragon",
                            Descripcion = "Un libro de fantasia",
                            Genero = [fantasia, terror]
                        }
                        ]
                },
                new()
                {
                    Nombre= "J. K. Rowling",
                    FechaNacimiento= new DateTime(1960,5,2),
                    Libros = [
                        new(){
                            Nombre = "Harry Potter y la piedra filosofal",
                            Descripcion = "Un libro de fantasia",
                            Genero = [fantasia]
                        }
                        ]
                }
            }; 

            // agrego de manera sincronica los autos con sus libros y generos
            context.Autores.AddRange(autores);
            context.SaveChanges();
        }
    }
}