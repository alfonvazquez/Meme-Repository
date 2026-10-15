using Microsoft.EntityFrameworkCore;
using memes_aspnet.Models;

namespace memes_aspnet.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // aplica  migraciones pendientes al arrancar la app
        context.Database.Migrate();

        // DATOS DEMO
        if (!context.Memes.Any())
        {
            context.Memes.AddRange(
                new Meme {Name = "Comunist Bugs Bunny", Description = "Bugs Bunny with the flag of communism behind"},
                new Meme {Name = "Pathetic", Description = "Professor Skinner from The Simpsons with subtitles saying 'Pathetic'"}
            );
            context.SaveChanges();
        }
        
    }
}