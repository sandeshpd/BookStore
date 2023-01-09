using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BookStore.Migrations;

namespace BookStore.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookStore.Data.BookStoreContext _context;

        public IndexModel(BookStore.Data.BookStoreContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public string? CurrentFilter { get; set; }
        public string? Language { get; set; }
        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }
        public string? Condition { get; set; }
        public IList<Book> Bookslang { get; set; }
        public async Task OnGetAsync(string? language_options, int? pageIndex)
        {
            if(language_options != null)
            {
                pageIndex = 1;
            }
            else
            {
                language_options = CurrentFilter;
            }    

            CurrentFilter = language_options;
            IQueryable<Book> BooksLanguage = from bl in _context.Book
                                             select bl;
            if (!string.IsNullOrEmpty(language_options))
            {
                BooksLanguage = BooksLanguage.Where(bl => bl.Language.Contains(language_options));
            }
            Bookslang = await BooksLanguage.AsNoTracking().ToListAsync();
        }
    }
}
