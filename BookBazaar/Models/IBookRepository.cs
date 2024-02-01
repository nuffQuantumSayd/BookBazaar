namespace BookBazaar.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
