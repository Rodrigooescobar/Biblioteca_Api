namespace Biblioteca.Data
{
    public static class Extensions
    {
        // Este metodo de extension crea la base de datos si no existe cuando la aplicacion arranca.
        public static void CreateDbIfNotExists(this IHost host)
        {
            // Crea un nuevo scope (alcance) para los servicios.
            // Esto es importante para gestionar correctamente la vida util de los servicios con ciclo de vida 'scoped'.
            using var scope = host.Services.CreateScope();

            // Obtiene el ServiceProvider que permite resolver servicios dentro del scope creado.
            var services = scope.ServiceProvider;

            // Obtiene una instancia del contexto de base de datos desde el contenedor de dependencias.
            // Si 'BibliotecaDbContext' no está registrado en el contenedor, se lanzará una excepción.
            var context = services.GetRequiredService<BibliotecaDbContext>();

            // Asegura que la base de datos asociada con el contexto se haya creado.
            // Si la base de datos no existe, se crea automáticamente en este punto.
            context.Database.EnsureCreated();

            // Inicializa la base de datos con datos en la clase DBInitializer
            DBInitializer.Initialize(context);
        }
    }
}
