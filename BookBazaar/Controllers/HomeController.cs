using BookBazaar.Data;
using BookBazaar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookBazaar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string searchString)
        {   
            // If the database is empty, return a problem
            if (_context.Books == null)
            {
                return Problem("The database is empty");
            }

            // If the search string is empty, return all books
            var books = from b in _context.Books
                        select b;

            // If the search string is not empty, return books that contain the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title!.Contains(searchString));
            }

            // Return the view with the books
            return View(await books.ToListAsync());
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
}
