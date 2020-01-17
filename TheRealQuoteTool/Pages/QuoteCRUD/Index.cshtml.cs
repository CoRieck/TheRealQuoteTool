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
    public class IndexModel : PageModel
    {
        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public IndexModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
        {
            _context = context;
        }

        public IList<QuoteModel> QuoteModel { get;set; }

        public async Task OnGetAsync()
        {
            QuoteModel = await _context.QuoteModel.ToListAsync();
        }
    }
}
