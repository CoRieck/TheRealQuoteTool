using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheRealQuoteTool.Models;

namespace TheRealQuoteTool.Data
{
    public class TheRealQuoteToolContext : DbContext
    {
        public TheRealQuoteToolContext (DbContextOptions<TheRealQuoteToolContext> options)
            : base(options)
        {
        }

        public DbSet<TheRealQuoteTool.Models.QuoteModel> QuoteModel { get; set; }
        public DbSet<TheRealQuoteTool.Models.TaskModel> TaskModel { get; set; }
        public DbSet<TheRealQuoteTool.Models.TaskLookupModel> TaskLookupModel { get; set; }
    }
}
