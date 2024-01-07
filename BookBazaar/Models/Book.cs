using System.ComponentModel.DataAnnotations;

namespace BookBazaar.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public Genre Genre { get; set; }

        public int Quantity { get; set; }
    
    }
}
