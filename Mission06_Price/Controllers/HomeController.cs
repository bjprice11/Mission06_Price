using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Price.Models;


namespace Mission06_Price.Controllers;

public class HomeController : Controller
{
    //sets the Movie database to be private so others cant access it
    private MovieDatabaseContext _context;

    //Public constructor so others can add things to the database
    public HomeController(MovieDatabaseContext temp)
    {
        _context = temp;
    }
    //Sends to the home page
    public IActionResult Index()
    {
        return View();
    }
    //Sends to the get to know page
    public IActionResult GetToKnow()
    {
        return View();
    }
    //Sends to the movie form page
    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }
    //Recieves the responses from the form and sends them to the database
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.MovieDatabase.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
 
}