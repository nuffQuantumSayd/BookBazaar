﻿namespace BookBazaar.Models
{
    public class CartItem
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}
