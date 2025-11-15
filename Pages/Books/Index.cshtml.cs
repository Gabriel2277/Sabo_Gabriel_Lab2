using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sabo_Gabriel_Lab2.Data;
using Sabo_Gabriel_Lab2.Models;

namespace Sabo_Gabriel_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Sabo_Gabriel_Lab2.Data.Sabo_Gabriel_Lab2Context _context;

        public IndexModel(Sabo_Gabriel_Lab2.Data.Sabo_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        // A fost păstrată doar această metodă (cea cu parametri opționali)
        // deoarece se potrivește și cu ruta goală, rezolvând conflictul.
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            // Logica completă pentru preluarea cărților
            BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }

            // Asigurăm că proprietatea simplă 'Book' este de asemenea populată, 
            // în cazul în care view-ul o folosește în alte scopuri.
            Book = BookD.Books.ToList();
        }

        // Metoda public async Task OnGetAsync() fără parametri a fost eliminată
        // pentru a rezolva eroarea "Multiple handlers matched".
    }
}