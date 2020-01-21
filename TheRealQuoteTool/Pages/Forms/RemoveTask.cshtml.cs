using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheRealQuoteTool.Models;
using Microsoft.EntityFrameworkCore;

namespace TheRealQuoteTool
{
    public class RemoveTaskModel : PageModel
    {

        private readonly TheRealQuoteTool.Data.TheRealQuoteToolContext _context;

        public RemoveTaskModel(TheRealQuoteTool.Data.TheRealQuoteToolContext context)
        {
            _context = context;
        }


        public void OnGet()
        {

        }
    }
}