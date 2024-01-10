using System.ComponentModel.DataAnnotations;

namespace BookBazaar.Models
{
    public class CartItem
    {
        [Key]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}
