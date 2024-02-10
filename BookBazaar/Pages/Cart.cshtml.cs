using BookBazaar.Infrastructure;
using BookBazaar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookBazaar.Pages
{
    // This is the model for the Cart page
    public class CartModel : PageModel
    {
        private IBookRepository repository;

        // This is the constructor for the CartModel
        public CartModel(IBookRepository repo, Cart cartServicee)
        {
            repository = repo;
            Cart = cartServicee;
        }

        // The Cart property
        public Cart? Cart { get; set; }

        // The ReturnUrl property
        public string ReturnUrl { get; set; } = "/";

        // This method handles the GET request
        public void OnGet(string returnUrl)
        {
            // If the returnUrl is not null, set the ReturnUrl property to the returnUrl
            ReturnUrl = returnUrl ?? "/";
        }

        // This method handles the POST request
        public IActionResult OnPost(Book addedBook, string returnUrl)
        {
            // Get the book with the given bookId
            Book? book = repository.Books
                .FirstOrDefault(b => b.Id == addedBook.Id);

            // If the book is not null, add the book to the cart in the session
            if (book != null)
            {
                // Add the book to the cart
                Cart?.AddItem(book, 1);
            }

            // If the returnUrl is not null, return to the returnUrl
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        // This method handles the POST request
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            // Remove the book with the given bookId from the cart in the session
            Cart?.RemoveLine(Cart.Lines.First(cl =>
            cl.Book.Id == bookId).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
