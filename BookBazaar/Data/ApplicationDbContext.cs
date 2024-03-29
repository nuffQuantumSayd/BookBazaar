﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookBazaar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookBazaar.Models.Book> Books { get; set; }
        public DbSet<BookBazaar.Models.Order> Orders { get; set; }
        public DbSet<BookBazaar.Models.Contact> Contacts { get; set; }

    }
}
