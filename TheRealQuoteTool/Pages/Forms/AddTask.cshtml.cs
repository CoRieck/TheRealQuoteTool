using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheRealQuoteTool.Models;

namespace TheRealQuoteTool.Pages.Forms
{
    public class AddTaskModel : PageModel
    {

        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public AddTaskModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
        {
            _context = context;
        }

        public IList<TaskLookupModel> TaskLookupList { get; set; }
        public IList<QuoteModel> QuoteModelList { get; set; }

        [BindProperty(SupportsGet = true)]
        public TaskModel TaskModel { get; set; }
        

        public async Task OnGetAsync()
        {
            TaskLookupList = await _context.TaskLookupModel.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddTask(decimal totalHours, decimal totalPrice, string taskTitle, int quoteID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            QuoteModelList = await _context.QuoteModel.ToListAsync();
            TaskModel.totalHours = totalHours;
            TaskModel.totalPrice = totalPrice;
            TaskModel.Title = taskTitle;
            TaskModel.quoteID = quoteID;

            foreach(var item in QuoteModelList)
            {
                if (item.ID == quoteID)
                {
                    item.totalHours += totalHours;
                    item.totalCost += totalPrice;
                }
            }

            _context.TaskModel.Add(TaskModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Forms/AddQuote");
        }
    }
}
