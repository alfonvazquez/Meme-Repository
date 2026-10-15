using memes_aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace memes_aspnet.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // TABLAS
    public DbSet<Meme> Memes => Set<Meme>();
    public DbSet<KeyWord> KeyWords => Set<KeyWord>();

    
}