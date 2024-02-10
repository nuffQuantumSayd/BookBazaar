using Microsoft.AspNetCore.Mvc;
using BookBazaar.Models;

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
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new {orderId = order.OrderId});
            }
            else
            {
                return View();
            }
        }
    }
}
