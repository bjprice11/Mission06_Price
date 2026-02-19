using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //generates the dropdown with the categories
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        return View();
    }
    //Recieves the responses from the form and sends them to the database
    [HttpPost]
    public IActionResult MovieForm(Movies response)
    {
        //Checks to make sure all the values are valid
        if (ModelState.IsValid){
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }
        else // Otherwise reloads the page with the categories dropdown
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View(response);
        }
        
    }

    public IActionResult MovieList()
    {
        //Makes a movies list to pass into the MovieList
        var movies = _context.Movies
            .Include(x => x.Categories)
            .ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        //Selects the movie with the mathcing ID that was passed in
        var MovieToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        //Recreates the categories drop down
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        return View("MovieForm", MovieToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movies UpdatedMovie)
    {
        //updates the Movie with the same id in the database
        if (ModelState.IsValid)
        {
            _context.Movies.Update(UpdatedMovie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("MovieForm", UpdatedMovie);
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        //Gets movie to delete according to id
        var MovieToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        return View(MovieToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movies movie)
    {
        //Removes the entry with that id from the database
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

}