using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookBazaar.Data;
using BookBazaar.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookBazaar.Controllers
{
    // restrict to admin 
    [Authorize(Roles = "Administrator")]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Books
        public async Task<IActionResult> Index(string currentFilter, string searchString)
        {
            if(_context.Books == null)
            {
                return Problem("The database is empty");
            }
            IQueryable<Book> books = from b in _context.Books
                                     select b;

            // If the search string is empty, return all books
            if (searchString != null)
            {
                ViewBag.CurrentFilter = searchString;
            }
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

            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel bookModel)
        {
            

            if (ModelState.IsValid)
            {
                // Generate a unique name for the image
                string fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(bookModel.BookPhoto.FileName);

                // Save file to file system
                string uploadPath = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using Stream fileStream = new FileStream(uploadPath, FileMode.Create);
                await bookModel.BookPhoto.CopyToAsync(fileStream);

                // Map the view model to the data model (Book), save to the database
                Book book = new Book
                {
                    Title = bookModel.Title,
                    ISBN = bookModel.ISBN,
                    Author = bookModel.Author,
                    Description = bookModel.Description,
                    Genre = bookModel.Genre,
                    Quantity = bookModel.Quantity,
                    Price = bookModel.Price,
                    Image = fileName
                };

                // Add the book to the database
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookModel);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            EditBookViewModel bookModel = new EditBookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                Quantity = book.Quantity,
                Price = book.Price,
            };

            return View(bookModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBookViewModel bookModel)
        {
            // Generate a unique name for the image
            string fileName = Guid.NewGuid().ToString();
            fileName += Path.GetExtension(bookModel.BookPhoto.FileName);

            // Save file to file system
            string uploadPath = Path.Combine(_environment.WebRootPath, "Images", fileName);
            using Stream fileStream = new FileStream(uploadPath, FileMode.Create);
            await bookModel.BookPhoto.CopyToAsync(fileStream);

            if (ModelState.IsValid)
            {
                Book? book = _context.Books.Find(bookModel.Id);

                book.Title = bookModel.Title;
                book.ISBN = bookModel.ISBN;
                book.Author = bookModel.Author;
                book.Description = bookModel.Description;
                book.Genre = bookModel.Genre;
                book.Quantity = bookModel.Quantity;
                book.Price = bookModel.Price;
                book.Image = fileName;


                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(bookModel);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
