using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Serre.Models;

namespace Mission06_Serre.Controllers
{
    // This controller handles requests for the main pages of the application.
    public class HomeController : Controller
    {
        private MovieCollectionContext _context; // Database context for accessing movie data

        // Constructor that initializes the database context
        public HomeController(MovieCollectionContext temp)
        {
            _context = temp;
        }

        // Loads the homepage (Index view)
        public IActionResult Index()
        {
            return View();
        }

        // Loads the "Get to Know Joel" page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Handles the GET request for the Movie Collection form (displays the form)
        [HttpGet]
        public IActionResult MovieCollection()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieCollection", new Movie());
        }

        // Handles the POST request when a user submits the Movie Collection form
        [HttpPost]
        public IActionResult MovieCollection(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Adds the new movie record to the database
                _context.SaveChanges(); // Saves changes to the database

                return RedirectToAction("MovieList"); // Redirects to confirmation page with submitted data
            }

            else //Invalid data
            {
                ViewBag.Categories = _context.Categories
               .OrderBy(x => x.CategoryName)
               .ToList();

                return View(response);
            }

           
        }

        // Displays the Movie Confirmation page after submission
        public IActionResult MovieConfirmation()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(x => x.Category) //Name of the table you want to join
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieCollection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();


            return RedirectToAction("MovieList");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
