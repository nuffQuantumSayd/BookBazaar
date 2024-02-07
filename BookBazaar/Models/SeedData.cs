using BookBazaar.Data;
using Microsoft.EntityFrameworkCore;

namespace BookBazaar.Models
{
    /// <summary>
    /// This class is used to populate the Books table in the database with some initial data
    /// </summary>
    public class SeedData
    {
        public static void PopulateBooks(IApplicationBuilder app)
        {
            // Create a new scope to obtain a new ApplicationDbContext instance
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // If there are any pending migrations, apply them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // If there are no books in the database, add some initial data
            if (!context.Books.Any())
            {
                context.AddRange(
                    new Book
                    {
                        Title = "The Great Gatsby",
                        ISBN = "9780743273565",
                        Author = "F. Scott Fitzgerald",
                        Description = "The Great Gatsby is a novel by American author F. Scott Fitzgerald. It follows a cast of characters living in the fictional towns of West Egg and East Egg on prosperous Long Island in the summer of 1922.",
                        Genre = "Fiction",
                        Quantity = 10,
                        Price = 10.99,
                        Image = "TheGreatGatsby.jpg"
                    },
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        ISBN = "9780061120084",
                        Author = "Harper Lee",
                        Description = "To Kill a Mockingbird is a novel by Harper Lee published in 1960. It was immediately successful, winning the Pulitzer Prize, and has become a classic of modern American literature.",
                        Genre = "Fiction",
                        Quantity = 8,
                        Price = 12.50,
                        Image = "ToKillAMockingBird.jpg"
                    },
                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        ISBN = "9780316769488",
                        Author = "J.D. Salinger",
                        Description = "The Catcher in the Rye is a story by J.D. Salinger, partially published in serial form in 1945–1946 and as a novel in 1951.",
                        Genre = "Fiction",
                        Quantity = 12,
                        Price = 11.25,
                        Image = "TheCatcherInTheRye.jpg"
                    },
                    new Book
                    {
                        Title = "1984",
                        ISBN = "9780451524935",
                        Author = "George Orwell",
                        Description = "1984 is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.",
                        Genre = "Fiction",
                        Quantity = 15,
                        Price = 9.75,
                        Image = "1984.jpg"
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        ISBN = "9780141439518",
                        Author = "Jane Austen",
                        Description = "Pride and Prejudice is an 1813 romantic novel of manners written by Jane Austen.",
                        Genre = "Fiction",
                        Quantity = 20,
                        Price = 8.99,
                        Image = "PrideAndPrejudice.jpg"
                    },
                    new Book
                    {
                        Title = "Moby-Dick",
                        ISBN = "9780142437247",
                        Author = "Herman Melville",
                        Description = "Moby-Dick; or, The Whale is an 1851 novel by American writer Herman Melville.",
                        Genre = "Fiction",
                        Quantity = 10,
                        Price = 14.25,
                        Image = "Moby-Dick.jpg"
                    },
                    new Book
                    {
                        Title = "The Hobbit",
                        ISBN = "9780261102217",
                        Author = "J.R.R. Tolkien",
                        Description = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien. It was published on 21 September 1937 to wide critical acclaim, being nominated for the Carnegie Medal and awarded a prize from the New York Herald Tribune for best juvenile fiction.",
                        Genre = "Fantasy",
                        Quantity = 18,
                        Price = 11.99,
                        Image = "TheHobbit.jpg"
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        ISBN = "9780544003415",
                        Author = "J.R.R. Tolkien",
                        Description = "The Lord of the Rings is an epic high-fantasy novel by English author and scholar J. R. R. Tolkien.",
                        Genre = "Fantasy",
                        Quantity = 25,
                        Price = 29.99,
                        Image = "TheLordOfTheRings.jpg"
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Philosopher's Stone",
                        ISBN = "9781408855652",
                        Author = "J.K. Rowling",
                        Description = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry.",
                        Genre = "Fantasy",
                        Quantity = 30,
                        Price = 15.50,
                        Image = "HarryPotter.jpg"
                    },
                    new Book
                    {
                        Title = "The Hunger Games",
                        ISBN = "9780439023528",
                        Author = "Suzanne Collins",
                        Description = "The Hunger Games is a dystopian novel by the American writer Suzanne Collins. It is written in the voice of 16-year-old Katniss Everdeen, who lives in the future, post-apocalyptic nation of Panem in North America.",
                        Genre = "Fantasy",
                        Quantity = 20,
                        Price = 10.75,
                        Image = "TheHungerGames.jpg"
                    },
                    new Book
                    {
                        Title = "Dune",
                        ISBN = "9780441172719",
                        Author = "Frank Herbert",
                        Description = "Dune is a science fiction novel by American author Frank Herbert, originally published by Chilton Books in 1965.",
                        Genre = "Sci-Fi",
                        Quantity = 22,
                        Price = 13.25,
                        Image = "Dune.jpg"
                    },
                    new Book
                    {
                        Title = "Neuromancer",
                        ISBN = "9780441569595",
                        Author = "William Gibson",
                        Description = "Neuromancer is a 1984 science fiction novel by American-Canadian writer William Gibson.",
                        Genre = "Sci-Fi",
                        Quantity = 18,
                        Price = 12.99,
                        Image = "Neuromancer.jpg"
                    },
                    new Book
                    {
                        Title = "Foundation",
                        ISBN = "9780553293357",
                        Author = "Isaac Asimov",
                        Description = "Foundation is a science fiction novel by American writer Isaac Asimov. It is the first published in his Foundation Trilogy.",
                        Genre = "Sci-Fi",
                        Quantity = 14,
                        Price = 11.99,
                        Image = "Foundation.jpg"
                    },
                    new Book
                    {
                        Title = "The Hitchhiker's Guide to the Galaxy",
                        ISBN = "9780345391803",
                        Author = "Douglas Adams",
                        Description = "The Hitchhiker's Guide to the Galaxy is a comic science fiction series created by Douglas Adams that has become popular among fans of the genre and members of the scientific community.",
                        Genre = "Sci-Fi",
                        Quantity = 25,
                        Price = 9.99,
                        Image = "HitchhikersGuide.jpg"
                    },
                    new Book
                    {
                        Title = "Jurassic Park",
                        ISBN = "9780345370778",
                        Author = "Michael Crichton",
                        Description = "Jurassic Park is a 1990 science fiction novel written by Michael Crichton, divided into seven sections, each plotting the sequence of events and discoveries throughout the history of the fictional Jurassic Park.",
                        Genre = "Sci-Fi",
                        Quantity = 20,
                        Price = 14.99,
                        Image = "JurassicPark.jpg"
                    },
                    new Book
                    {
                        Title = "The Da Vinci Code",
                        ISBN = "9780307474278",
                        Author = "Dan Brown",
                        Description = "The Da Vinci Code is a mystery thriller novel by Dan Brown. It is Brown's second novel to include the character Robert Langdon: the first was his 2000 novel Angels & Demons.",
                        Genre = "Mystery",
                        Quantity = 20,
                        Price = 11.25,
                        Image = "DaVinciCode.jpg"
                    },
                    new Book
                    {
                        Title = "Gone Girl",
                        ISBN = "9780307588371",
                        Author = "Gillian Flynn",
                        Description = "Gone Girl is a thriller novel in the mystery and crime genres, by the American writer Gillian Flynn. It was published by Crown Publishing Group in June 2012.",
                        Genre = "Mystery",
                        Quantity = 15,
                        Price = 10.99,
                        Image = "GoneGirl.jpg"
                    },
                    new Book
                    {
                        Title = "The Girl with the Dragon Tattoo",
                        ISBN = "9780307269751",
                        Author = "Stieg Larsson",
                        Description = "The Girl with the Dragon Tattoo is a psychological thriller novel by Swedish author and journalist Stieg Larsson (1954–2004), which was published posthumously in 2005 to become an international bestseller.",
                        Genre = "Mystery",
                        Quantity = 18,
                        Price = 12.75,
                        Image = "GirlDragonTattoo.jpg"
                    },
                    new Book
                    {
                        Title = "The Silence of the Lambs",
                        ISBN = "9780312924584",
                        Author = "Thomas Harris",
                        Description = "The Silence of the Lambs is a psychological horror novel by Thomas Harris. First published in 1988, it is the sequel to Harris's 1981 novel Red Dragon.",
                        Genre = "Mystery",
                        Quantity = 12,
                        Price = 13.50,
                        Image = "SilenceOfTheLambs.jpg"
                    },
                    new Book
                    {
                        Title = "And Then There Were None",
                        ISBN = "9780062073488",
                        Author = "Agatha Christie",
                        Description = "And Then There Were None is a mystery novel by English writer Agatha Christie, described by her as the most difficult of her books to write.",
                        Genre = "Mystery",
                        Quantity = 16,
                        Price = 8.50,
                        Image = "ThereWereNone.jpg"
                    },
                    new Book
                    {
                        Title = "Dune Messiah",
                        ISBN = "9780593201732",
                        Author = "Frank Herbert",
                        Description = "Set in a distant future where interstellar empires vie for control, 'Dune Messiah' follows the gripping tale of Paul Atreides. 'Dune Messiah' is a must-read for fans of the genre.",
                        Genre = "Sci-Fi",
                        Quantity = 3,
                        Price = 14.99,
                        Image = "DuneMessiah.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
