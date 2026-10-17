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
                new Meme {Name = "Communist Bugs Bunny", Description = "Bugs Bunny with the flag of communism behind", Gen = Gen.Milenial, ImageFileName = "Communist_Bugs_Bunny.jpg"},
                new Meme {Name = "Pathetic", Description = "Professor Skinner from The Simpsons with subtitles saying 'Pathetic'", Gen = Gen.Milenial, ImageFileName = "Pathetic_Skinner.png"}
            );
            context.SaveChanges();
        }

        if (!context.KeyWords.Any())
        {
            var communistBugsBunny = context.Memes.First(r => r.Name == "Communist Bugs Bunny");
            var pathetic = context.Memes.First(r => r.Name == "Pathetic");

            context.KeyWords.AddRange(
                new KeyWord {Word = "BugsBunny", Meme = communistBugsBunny},
                new KeyWord {Word = "Communist", Meme = communistBugsBunny},
                new KeyWord {Word = "Bugs Bunny", Meme = communistBugsBunny},
                new KeyWord {Word = "Pathetic", Meme = pathetic},
                new KeyWord {Word = "Simpsons", Meme = pathetic}
            );
            context.SaveChanges();
        }

        Console.WriteLine($"Memes in the database: {context.Memes.Count()}");
        Console.WriteLine($"Keywords in the database: {context.KeyWords.Count()}");
        
    }
}