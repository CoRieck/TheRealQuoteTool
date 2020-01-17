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
    public class DetailsModel : PageModel
    {
        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public DetailsModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
        {
            _context = context;
        }

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
    }
}
