using Microsoft.Identity.Client;

namespace BookBazaar.Models
{
    public class Cart
    {
        // Lines property
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        // AddItem method
        public void AddItem(Book book, int quantity)
        {
            // Find the book in the cart
            CartLine? line = Lines
                .Where(b => b.Book.Id == book.Id)
                .FirstOrDefault();

            // If the book is not in the cart, add it
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            // Otherwise, update the quantity
            else
            {
                line.Quantity += quantity;

            }

        }

        // RemoveLine method
        public void RemoveLine(Book book)
        {
            Lines.RemoveAll(l => l.Book.Id == book.Id);
        }

        // ComputeTotalValue method
        public double ComputeTotalValue()
        {
            return Lines.Sum(e => e.Book.Price * e.Quantity);
        }

        // Clear method
        public void Clear()
        {
            Lines.Clear();
        }

        // CartLine class
        public class CartLine
        {
            // CartLineID property
            public int CartLineID { get; set; }

            // Book property
            public Book Book { get; set; }

            // Quantity property    
            public int Quantity { get; set; }
        }
    }
}
