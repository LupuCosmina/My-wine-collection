using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_wine_collection.Data;
using My_wine_collection.Models;

namespace My_wine_collection.Pages.Types
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
        ViewData["TypeID"] = new SelectList(_context.Type, "ID", "ID");
        ViewData["WineID"] = new SelectList(_context.Wine, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public WineType WineType { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WineType.Add(WineType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
