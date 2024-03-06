using BookBazaar.Data;
using BookBazaar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace BookBazaar.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult AvailableBooks(string currentFilter, string searchString, int? page)
        {
            // If the database is empty, return a problem
            if (_context.Books == null)
            {
                return Problem("The database is empty");
            }

            // If the search string is empty, return all books
            IQueryable<Book> books = from b in _context.Books
                                     select b;

            // If the search string is not empty, return books that contain the search string
            if (searchString != null)
            {
                page = 1;
            }
            // If the search string is empty, return all books
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            // If the search string is not empty, return books that contain the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title!.Contains(searchString));
            }

            // Set the page size and number
            int pageSize = 4;

            // Return the page number
            int pageNumber = (page ?? 1);

            // Return the view with the books 
            IPagedList<Book> pagedBookList = books.ToPagedList(pageNumber, pageSize);

            return View(pagedBookList);
        }

        // GET: Books
        public IActionResult Index()
        {   
            // If the database is empty, return a problem
            if (_context.Books == null)
            {
                return Problem("The database is empty");
            }

            IQueryable<Book> books = from b in _context.Books
                                     where b.Id < 5
                                     select b;

            return View(books);
        }

        public IActionResult BookDescription(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // return the book with the given id
            var book = _context.Books
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book); 
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
