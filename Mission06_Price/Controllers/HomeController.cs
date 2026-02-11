using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Price.Models;


namespace Mission06_Price.Controllers;

public class HomeController : Controller
{
    private MovieDatabaseContext _context;

    public HomeController(MovieDatabaseContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.MovieDatabase.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
 
}