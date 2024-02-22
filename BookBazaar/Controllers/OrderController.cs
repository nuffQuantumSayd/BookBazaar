using Microsoft.AspNetCore.Mvc;
using BookBazaar.Models;
using Stripe.Checkout;

namespace BookBazaar.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        // This is the constructor for the OrderController
        public OrderController(IOrderRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        // This is the Completed method that returns the Completed view
        public ViewResult Checkout() => View(new Order());
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            // If the cart is empty, add a model error
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            // If the model state is valid, save the order
            if (ModelState.IsValid)
            {
                // Save the order
                repository.SaveOrder(order);


                string domain = "https://localhost:7046/";
                // Create a new session with the order details
                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"Completed?orderId={order.OrderId}",
                    CancelUrl = domain + "Cart",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                // Add the items in the cart to the session
                foreach (var item in cart.Lines)
                {
                    var sessionListItem = new SessionLineItemOptions()
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmountDecimal = (long)(item.Book.Price * 100),
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Book.Title,

                            }
                        },
                        Quantity = item.Quantity,
                    };
                    options.LineItems.Add(sessionListItem);
                }

                // Create the session
                SessionService service = new SessionService();

                // This is the session object that will be returned to the client
                Session session = service.Create(options);

                // Redirect the user to the session URL
                Response.Headers.Add("Location", session.Url);
                
                // Clear the cart
                cart.Clear();

                // Return a 303 status code
                return StatusCode(303);   
            }
            else
            {
                return View();
            }            
        }
    }
}
