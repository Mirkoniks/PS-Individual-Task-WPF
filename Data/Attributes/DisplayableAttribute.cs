using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DisplayableAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public DisplayableAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
