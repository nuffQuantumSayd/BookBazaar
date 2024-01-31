
using BookBazaar.Data;

namespace BookBazaar.Models
{
    // This is the model for the Book table in the database
    public class EFBookRepository : IBookRepository
    {
        private ApplicationDbContext _context;

        // This is the constructor for the EFBookRepository
        public EFBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
