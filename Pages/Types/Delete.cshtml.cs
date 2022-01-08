using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_wine_collection.Data;
using My_wine_collection.Models;

namespace My_wine_collection.Pages.Types
{
    public class DeleteModel : PageModel
    {
        private readonly My_wine_collection.Data.My_wine_collectionContext _context;

        public DeleteModel(My_wine_collection.Data.My_wine_collectionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WineType WineType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WineType = await _context.WineType
                .Include(w => w.Type)
                .Include(w => w.Wine).FirstOrDefaultAsync(m => m.ID == id);

            if (WineType == null)
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

            WineType = await _context.WineType.FindAsync(id);

            if (WineType != null)
            {
                _context.WineType.Remove(WineType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
