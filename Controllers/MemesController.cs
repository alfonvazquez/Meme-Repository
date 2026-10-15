using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using memes_aspnet.Data;
using memes_aspnet.Models;

namespace memes_aspnet.Controllers;

public class MemesController : Controller
{
    private readonly ApplicationDbContext context;

    public MemesController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index(string? search, Gen? gen)
    {
        var query = context.Memes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(r => r.Name.ToLower().Contains(search.ToLower()));
        }

        if (gen != null)
        {
            query = query.Where(r => r.Gen == gen);
        }


        ViewBag.Search = search;
        ViewBag.Gen = gen;

        var memes = query.OrderBy(r => r.Name).ToList();
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


