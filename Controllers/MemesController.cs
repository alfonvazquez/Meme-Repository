using Microsoft.AspNetCore.Mvc;
using memes_aspnet.Data;

namespace memes_aspnet.Controllers;

public class MemesController : Controller
{
    private readonly ApplicationDbContext context;

    public MemesController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var memes = context.Memes.ToList();
        return View(memes);
    }
    
    public IActionResult Details(int id)
    {
        var meme = context.Memes.Find(id);
        if (meme == null)
        {
            return NotFound();
        }

        return View(meme);
    }
}


