using Microsoft.EntityFrameworkCore;

namespace memes_aspnet.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // TABLAS
    
}