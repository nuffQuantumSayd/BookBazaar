using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookBazaar.Models
{
    /// <summary>
    /// the contact model
    /// </summary>
    public class Contact
    {
        // the contact ID
        public int ContactId { get; set; }

        // user ID from AspNetUser table.
        public string? OwnerID { get; set; }
        [ForeignKey("OwnerID")]

        // the contact name
        public string? Name { get; set; }

        // the contact address
        public string? Address { get; set; }

        // the contact city
        public string? City { get; set; }

        // the contact state
        public string? State { get; set; }

        // the contact zip
        public string? Zip { get; set; }

        // the contact email
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
