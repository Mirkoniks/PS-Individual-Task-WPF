using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public interface ISerachable<T, D>
    {
        public List<T> SearchRecords(D SerachDto);
    }
}
