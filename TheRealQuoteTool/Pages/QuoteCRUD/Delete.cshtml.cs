using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheRealQuoteTool.Data;
using TheRealQuoteTool.Models;

namespace TheRealQuoteTool
{
    public class DeleteModel : PageModel
    {
        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public DeleteModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public QuoteModel QuoteModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuoteModel = await _context.QuoteModel.FirstOrDefaultAsync(m => m.ID == id);

            if (QuoteModel == null)
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

            QuoteModel = await _context.QuoteModel.FindAsync(id);

            if (QuoteModel != null)
            {
                _context.QuoteModel.Remove(QuoteModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
