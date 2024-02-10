using BookBazaar.Infrastructure;
using System.Text.Json.Serialization;

namespace BookBazaar.Models
{
    public class SessionCart : Cart
    {
        // GetCart method
        public static Cart GetCart(IServiceProvider services)
        {
            // Get the session
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            // Get the cart from the session
            SessionCart? cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();

            // Set the session
            cart.Session = session;

            return cart;
        }

        // Session property
        [JsonIgnore]
        public ISession? Session { get; set; }

        // AddItem method
        public override void AddItem(Book book, int quantity)
        {
            // Call the base AddItem method
            base.AddItem(book, quantity);
            // Set the session
            Session?.SetJson("Cart", this);
        }
        
        // RemoveLine method
        public override void RemoveLine(Book book)
        {
            // Call the base RemoveLine method
            base.RemoveLine(book);
            // Set the session
            Session?.SetJson("Cart", this);
        }

        // Clear method
        public override void Clear()
        {
            // Call the base Clear method
            base.Clear();
            // Set the session
            Session?.Remove("Cart");
        }
    }
}
