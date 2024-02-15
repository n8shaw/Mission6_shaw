using Microsoft.AspNetCore.Mvc;
using Mission6_shaw.Models;
using System.Diagnostics;

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
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieRating response) 
        {
            _context.MovieData.Add(response);//add record to database
            _context.SaveChanges();//save changes

            return View("Confirmation", response);//route confimation view


        }

      
    }
}
