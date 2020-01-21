using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheRealQuoteTool.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TheRealQuoteTool
{
    public class AddQuoteModel : PageModel
    {
        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public AddQuoteModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
        {
            _context = context;
        }

        public IList<QuoteModel> QuoteModelList { get; set; }
        public IList<TaskModel> TaskModelList { get; set; }




        [BindProperty]
        public QuoteModel QuoteModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostNewQuote()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            QuoteModel.dateCreated = DateTime.Now;
            QuoteModel.totalCost = 0;
            QuoteModel.totalHours = 0;

            _context.QuoteModel.Add(QuoteModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Forms/AddQuote");
        }

        public RedirectToPageResult OnPostNewTask(int ID)
        {
            return RedirectToPage("/Forms/AddTask", new { quoteID  = ID});
        }

        public RedirectToPageResult OnPostRemoveTask(int ID)
        {
            return RedirectToPage("/Forms/RemoveTask", new { taskID = ID});
        }
            public async Task OnGetAsync()
        {
            QuoteModelList = await _context.QuoteModel.ToListAsync();
            TaskModelList = await _context.TaskModel.ToListAsync();
        }


    }
}