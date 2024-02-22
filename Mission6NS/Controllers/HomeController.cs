using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_shaw.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_shaw.Controllers
{
    public class HomeController : Controller
    {

        private MovieRatingContext _context;
        public HomeController(MovieRatingContext someName)
        {
            _context = someName;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _context.Categories.ToList();//returns all categores in the database
            return View(new MovieRating());
        }

        [HttpPost]
        public IActionResult Movies(MovieRating response) 
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);//add record to database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();//returns all categories in the database
                return View(response);
            }

        }

        public IActionResult MovieList()
        {
            //linq
            var movies = _context.Movies
                .Include(m => m.CategoryName)//adding the categories from the other table
                .OrderBy(x => x.Year).ToList();//grabbing all the movie records
                

            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);//grabs the movie to edit by the movie ID

            ViewBag.Categories = _context.Categories.ToList();
            return View("Movies", recordToEdit); //grabs all the categories
        }
        [HttpPost]
        public IActionResult Edit(MovieRating updatedInfo)
        {
            _context.Update(updatedInfo);//update the database
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                   .Single(x => x.MovieId == id);//grab the record to delete by the movie ID
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(MovieRating deletedInfo)
        {
            _context.Movies.Remove(deletedInfo);//delete the record
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
