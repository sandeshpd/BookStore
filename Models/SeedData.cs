using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookStoreContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null BookStoreContext");
                }

                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "The Alchemist",
                        Author = "Paulo Coelho",
                        Language = "English",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Philosophy",
                        Price = 450M,
                        Condition = "New"
                    },

                    new Book
                    {
                        Title = "Lord Of The Rings",
                        Author = "J.R.R Tolkien",
                        Language = "English",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Fantasy",
                        Price = 1000M,
                        Condition = "Used"
                    },

                    new Book
                    {
                        Title = "Durgabhraman Gatha",
                        Author = "G. N. Dandekar",
                        Language = "Marathi",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Travellogue",
                        Price = 250M,
                        Condition = "Used"
                    },

                    new Book
                    {
                        Title = "Sapiens: A Brief history of humankind",
                        Author = "Yuval Noah Harari",
                        Language = "English",
                        ReleaseDate = DateTime.Parse("2014-4-15"),
                        Genre = "History",
                        Price = 500M,
                        Condition = "New"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}