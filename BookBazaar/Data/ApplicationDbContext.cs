using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookBazaar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<BookBazaar.Models.Book> Books { get; set; }
        DbSet<BookBazaar.Models.ShoppingCart> ShoppingCarts { get; set;}
    }
}
