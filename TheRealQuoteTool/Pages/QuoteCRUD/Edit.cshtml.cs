using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRealQuoteTool.Data;
using TheRealQuoteTool.Models;

namespace TheRealQuoteTool
{
    public class EditModel : PageModel
    {
        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public EditModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(QuoteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteModelExists(QuoteModel.ID))
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

        private bool QuoteModelExists(int id)
        {
            return _context.QuoteModel.Any(e => e.ID == id);
        }
    }
}
