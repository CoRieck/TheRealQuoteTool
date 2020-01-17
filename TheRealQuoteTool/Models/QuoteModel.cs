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
        public decimal totalHours { get; set; }
        public decimal totalCost { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateCreated { get; set; }
        
    }
}
