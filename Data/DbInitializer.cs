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
        
    }
}