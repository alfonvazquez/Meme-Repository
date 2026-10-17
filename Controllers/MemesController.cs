using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using memes_aspnet.Data;
using memes_aspnet.Models;
using memes_aspnet.Services;

namespace memes_aspnet.Controllers;

public class MemesController : Controller
{
    private static readonly int[] AllowedPageSizes = [1, 2, 3];
    private readonly ApplicationDbContext context;

    private readonly ImageStorage images;

    public MemesController(ApplicationDbContext context, ImageStorage images)
    {
        this.context = context;
        this.images = images;
    }


    public IActionResult Index(string? search, Gen? gen, int size = 10, int page = 1)
    {
        var query = context.Memes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(r => r.Name.ToLower().Contains(search.ToLower())
                || r.KeyWords.Any(k => k.Word.ToLower().Contains(search.ToLower())));
        }

        if (gen != null)
        {
            query = query.Where(r => r.Gen == gen);
        }

        ViewBag.Search = search;
        ViewBag.Gen = gen;

        if (!AllowedPageSizes.Contains(size))
        {
            size = AllowedPageSizes[0];
        }

        var totalCount = query.Count();
        var totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)size));
        page = Math.Clamp(page, 1, totalPages);

        var memes = query
            .OrderBy(r => r.Name)
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();

        ViewBag.Page = page;
        ViewBag.TotalPages = totalPages;
        ViewBag.TotalCount = totalCount;
        ViewBag.Size = size;
        ViewBag.PageSizes = AllowedPageSizes;

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            Response.Headers["Vary"] = "X-Requested-With";
            return PartialView("_MemesList", memes);
        }

        Response.Headers["Vary"] = "X-Requested-With";
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

    [HttpGet]
    public IActionResult Create()
    {
        var meme = new Meme { };
        return View("Form", meme);
    }

    [HttpPost]
    public IActionResult Save(Meme meme, IFormFile? image)
    {
        if (!ModelState.IsValid)
        {
            return View("Form", meme);
        }

        meme.ImageFileName = null;

        if (image is not null && image.Length > 0)
        {
            var upload = images.Save(image, ImageFolder.MemesImg, meme.Name);
            if (!upload.Succeeded)
            {
                ModelState.AddModelError("image", upload.Error!);
                return View("Form", meme);
            }

            meme.ImageFileName = upload.FileName;
        }

        try
        {
            context.Memes.Add(meme);
            context.SaveChanges();
        }
        catch
        {
            images.Delete(meme.ImageFileName, ImageFolder.MemesImg);
            throw;
        }

        TempData["Message"] = "Meme saved.";
        return RedirectToAction("Details", new { id = meme.Id });
    }

}


