using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheRealQuoteTool.Models
{
    public class QuoteModel
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public string Author { get; set; }
        [Display(Name = "Total Hours")]
        public decimal totalHours { get; set; }
        [Display(Name = "Total Cost")]
        public decimal totalCost { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime dateCreated { get; set; }
        
    }
}
