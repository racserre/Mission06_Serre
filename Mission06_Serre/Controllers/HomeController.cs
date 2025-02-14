using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // Handles the POST request when a user submits the Movie Collection form
        [HttpPost]
        public IActionResult MovieCollection(Movie response)
        {
            _context.Movies.Add(response); // Adds the new movie record to the database
            _context.SaveChanges(); // Saves changes to the database

            return View("MovieConfirmation", response); // Redirects to confirmation page with submitted data
        }

        // Displays the Movie Confirmation page after submission
        public IActionResult MovieConfirmation()
        {
            return View();
        }
    }
}
