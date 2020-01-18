using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRealQuoteTool.Models
{
    public class TaskLookupModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal payRate { get; set; }
        public string description { get; set; }

    }
}
