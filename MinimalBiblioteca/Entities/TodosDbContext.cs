using Microsoft.EntityFrameworkCore;

namespace MinimalBiblioteca.Entities
{
    public class TodosDbContext : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>();
        public TodosDbContext(DbContextOptions<TodosDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // renombro la tabla, tmb puedo hacer con toda la esctructura
            modelBuilder.Entity<Todo>().ToTable("Todo");
        }
    }
}
