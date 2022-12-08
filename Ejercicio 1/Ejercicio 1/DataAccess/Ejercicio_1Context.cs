namespace Ejercicio_1.DataAccess;

public class Ejercicio_1Context : DbContext
{
    public Ejercicio_1Context(DbContextOptions<Ejercicio_1Context> options) : base(options)
    {

    }

    public DbSet<Curso>? Cursos { get; set; }
}
