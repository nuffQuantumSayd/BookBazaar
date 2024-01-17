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

        public string Genre { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }
    
    }

    public class CreateBookViewModel
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public IFormFile BookPhoto { get; set; }
    }
}
