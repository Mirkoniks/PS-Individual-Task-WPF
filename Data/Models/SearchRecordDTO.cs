using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SearchRecordDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }
        public string Product { get; set; }

        public string Keyword1 { get; set; }
        public string Keyword2 { get; set; }

        public  string  Year { get; set; }
    }
}
