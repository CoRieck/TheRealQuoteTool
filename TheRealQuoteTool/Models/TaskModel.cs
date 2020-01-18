using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRealQuoteTool.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public int quoteID { get; set; }
        public string Title { get; set; }
        public decimal payRate { get; set; }
        public decimal totalHours { get; set; }

        public decimal totalPrice { get; set; }
    }
}
