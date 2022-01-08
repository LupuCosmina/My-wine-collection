using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_wine_collection.Data;
using My_wine_collection.Models;

namespace My_wine_collection.Pages.Drinks
{
    public class CreateModel : PageModel
    {
        private readonly My_wine_collection.Data.My_wine_collectionContext _context;

        public CreateModel(My_wine_collection.Data.My_wine_collectionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducerID"] = new SelectList(_context.Set<Producer>(), "ID", "ProducerName");
            return Page();
        }

        [BindProperty]
        public Wine Wine { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Wine.Add(Wine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
