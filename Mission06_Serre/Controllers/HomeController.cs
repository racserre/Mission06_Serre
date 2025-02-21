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
            // Populates the dropdown list with categories, ordered alphabetically
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

                return RedirectToAction("MovieList"); // Redirects to movie list page with submitted data
            }
            else // Invalid data submitted, reload form with categories
            {
                // Ensures the category dropdown is populated if the form reloads due to validation errors
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

        // Displays the list of movies with their associated categories
        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(x => x.Category) // Eager-loads related Category data to avoid lazy-loading performance issues
                .OrderBy(x => x.Title) // Orders movies alphabetically by title
                .ToList();

            return View(movies);
        }

        // Handles GET request to load the Edit form with existing movie data
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id); // Retrieves the movie record by ID

            // Populates the category dropdown for editing
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieCollection", recordToEdit); // Reuses the MovieCollection view for editing
        }

        // Handles POST request to update movie details
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo); // Updates the movie record
            _context.SaveChanges(); // Saves changes to the database

            return RedirectToAction("MovieList"); // Redirects to the updated movie list
        }

        // Handles GET request to display a delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id); // Retrieves the movie to confirm deletion

            return View(recordToDelete);
        }

        // Handles POST request to delete a movie
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie); // Removes the movie from the database
            _context.SaveChanges(); // Saves changes

            return RedirectToAction("MovieList"); // Redirects to the updated movie list
        }
    }
}
