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
        public CartModel(IBookRepository repo)
        {
            repository = repo;
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

            // Set the Cart property to the cart in the session or a new cart
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        // This method handles the POST request
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // Get the book with the given bookId
            Book? book = repository.Books
                .FirstOrDefault(b => b.Id == bookId);

            // If the book is not null, add the book to the cart in the session
            if (book != null)
            {
                // Set the Cart property to the cart in the session or a new cart
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

                // Add the book to the cart
                Cart.AddItem(book, 1);

                // Set the cart in the session to the Cart property
                HttpContext.Session.SetJson("cart", Cart);
            }

            // If the returnUrl is not null, return to the returnUrl
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
