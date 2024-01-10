namespace BookBazaar.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public double TotalPrice { get; set; }


        public ShoppingCart()
        {
            CartItems = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            CartItems.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            CartItems.Remove(item);
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }

        public void UpdateCart(CartItem item)
        {
            CartItems[CartItems.FindIndex(i => i.BookId == item.BookId)] = item;
        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            foreach (CartItem item in CartItems)
            {
                total += item.Quantity * item.Book.Price;
            }
            return total;
        }
    }
    
}
