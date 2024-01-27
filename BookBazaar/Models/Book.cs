using System.ComponentModel.DataAnnotations;

namespace BookBazaar.Models
{
    // This is the model for the Book table in the database
    public class Book
    {
        // The Id field is required by the database for the primary key
        [Key]
        public int Id { get; set; }

        // The Title of the book
        public string Title { get; set; }

        // The ISBN of the book
        public string ISBN { get; set; }

        // The Author of the book
        public string Author { get; set; }

        // The Description of the book
        public string Description { get; set; }

        // The Genre of the book
        public string Genre { get; set; }

        // The Quantity of the book
        public int Quantity { get; set; }

        // The Price of the book
        public double Price { get; set; }

        // The Image of the book
        public string Image { get; set; }
    
    }

    // This is the model for the CreateBook view
    public class CreateBookViewModel
    {
        // The Title of the book
        public string Title { get; set; }

        // The ISBN of the book
        public string ISBN { get; set; }

        // The Author of the book
        public string Author { get; set; }

        // The Description of the book
        public string Description { get; set; }

        // The Genre of the book
        public string Genre { get; set; }

        // The Quantity of the book
        public int Quantity { get; set; }

        // The Price of the book
        public double Price { get; set; }

        // The Image of the book
        public IFormFile BookPhoto { get; set; }
    }
}
