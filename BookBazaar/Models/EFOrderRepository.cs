
using BookBazaar.Data;
using Microsoft.EntityFrameworkCore;

namespace BookBazaar.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // This is the Orders property that returns the Orders table from the database
        public IQueryable<Order> Orders => _context.Orders.Include(o => o.Lines).ThenInclude(l => l.Book);

        // This is the SaveOrder method that saves the order to the database
        public void SaveOrder(Order order)
        {
            // Attach the books to the context
            _context.AttachRange(order.Lines.Select(l => l.Book));

            // If the order does not exist, add it to the database
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
