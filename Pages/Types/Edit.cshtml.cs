using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_wine_collection.Data;
using My_wine_collection.Models;

namespace My_wine_collection.Pages.Types
{
    public class EditModel : PageModel
    {
        private readonly My_wine_collection.Data.My_wine_collectionContext _context;

        public EditModel(My_wine_collection.Data.My_wine_collectionContext context)
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
           ViewData["TypeID"] = new SelectList(_context.Type, "ID", "ID");
           ViewData["WineID"] = new SelectList(_context.Wine, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WineType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineTypeExists(WineType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WineTypeExists(int id)
        {
            return _context.WineType.Any(e => e.ID == id);
        }
    }
}
