using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using intro_to_asp_net.Models;
using System.IO;
using System.Linq;

namespace intro_to_asp_net.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Info()
    {
        return View();
    }
    
    public IActionResult Pictures()
    {
        string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        string[] imageFiles = Directory.GetFiles(imagesPath, "*.*", SearchOption.TopDirectoryOnly)
                                         .Where(file => file.EndsWith(".jpg") || file.EndsWith(".webp") || file.EndsWith(".png") || file.EndsWith(".gif"))
                                         .ToArray();

        return View(imageFiles);
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
