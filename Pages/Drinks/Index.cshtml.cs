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
    public class IndexModel : PageModel
    {
        private readonly My_wine_collection.Data.My_wine_collectionContext _context;

        public IndexModel(My_wine_collection.Data.My_wine_collectionContext context)
        {
            _context = context;
        }

        public IList<Wine> Wine { get;set; }

        public async Task OnGetAsync()
        {
            Wine = await _context.Wine
                .Include(b => b.Producer)
                .ToListAsync();
        }
    }
}
