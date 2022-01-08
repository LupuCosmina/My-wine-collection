using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_wine_collection.Data;
using My_wine_collection.Models;

namespace My_wine_collection.Pages.Drinks
{
    public class DeleteModel : PageModel
    {
        private readonly My_wine_collection.Data.My_wine_collectionContext _context;

        public DeleteModel(My_wine_collection.Data.My_wine_collectionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wine Wine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wine = await _context.Wine.FirstOrDefaultAsync(m => m.ID == id);

            if (Wine == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wine = await _context.Wine.FindAsync(id);

            if (Wine != null)
            {
                _context.Wine.Remove(Wine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
