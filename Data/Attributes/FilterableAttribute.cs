using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class FilterableAttribute : Attribute
    {
        public string FilterType { get; set; } // e.g., "Text", "Date", "Number"

        public FilterableAttribute(string filterType = "Text")
        {
            FilterType = filterType;
        }
    }
}
