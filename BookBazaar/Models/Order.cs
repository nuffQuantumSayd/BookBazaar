using BookBazaar.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BookBazaar.Models
{
    public class Order
    {
        [BindNever]
        // This attribute is used to exclude a property from the model binding process.
        public int OrderId { get; set; }

        // This is the cart
        public ICollection<Cart.CartLine> Lines { get; set; } = new List<Cart.CartLine>();

        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }

        // These are the lines of the address
        [Required(ErrorMessage = "Please enter the first address line")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }

        // This is the city
        [Required(ErrorMessage = "Please enter a city name")]
        public string? City{ get; set; }

        // This is the state
        [Required(ErrorMessage = "Please enter a state name")]
        public string? State { get; set; }

        // This is the zip code
        [Required(ErrorMessage = "Please enter a zip code")]
        public string? Zip { get; set; }

        // This is the country
        [Required(ErrorMessage = "Please enter a country name")]
        public string? Country { get; set; }

        // This is the gift wrap
        public bool GiftWrap { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}
