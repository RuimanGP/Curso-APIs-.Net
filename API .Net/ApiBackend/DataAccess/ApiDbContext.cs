namespace ApiBackend.DataAccess;

public class ApiDbContext: DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public ApiDbContext(DbContextOptions<ApiDbContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<Chapter>? Chapters { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Student>? Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var logger = _loggerFactory.CreateLogger<ApiDbContext>();
        
        optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
}

