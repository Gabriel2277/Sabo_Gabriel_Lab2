using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sabo_Gabriel_Lab2.Data;
using Sabo_Gabriel_Lab2.Models;

namespace Sabo_Gabriel_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Sabo_Gabriel_Lab2.Data.Sabo_Gabriel_Lab2Context _context;

        public CreateModel(Sabo_Gabriel_Lab2.Data.Sabo_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        private void PopulateDropdowns()
        {
            var authorList = _context.Author.Select(a =>
                              new {
                                  a.ID,
                                  FullName = a.FirstName + " " + a.LastName
                              });

            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");


            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
        }


        public IActionResult OnGet()
        {
            PopulateDropdowns(); 
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            _context.Book.Add(Book);


            await _context.SaveChangesAsync();



            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return Page(); 
            }

            return RedirectToPage("./Index");
        }
    }
}