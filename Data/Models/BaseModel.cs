using Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BaseModel<T>
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public List<T> SerachByYear(int year, string tableName)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                bool noResult = true;
                List<T> result = new List<T>();

                int minimalYear = GetMinimalYear(tableName);
                int currentYear = DateTime.Today.Year;

                while (noResult && year >= minimalYear && year <= currentYear)
                {
                    
                    var dbSetProperty = db.GetType().GetProperty(tableName);
                    var dbSet = dbSetProperty.GetValue(db);
                    var firstRecord = ((IEnumerable<object>)dbSet).Cast<dynamic>()
                                            .Where(r => r.Year == year)
                                            .ToList();


                    if (firstRecord.Count == 0)
                    {
                        year--;
                        continue;
                    }
                    else if (firstRecord.Count != 0)
                    {
                        noResult = false;

                        foreach (var record in firstRecord) 
                        {
                            T r = record;

                            result.Add(r);
                        }

                        return result;
                    }
                }

                return new List<T>();
            }
        }
        protected int GetMinimalYear(string tableName)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var dbSetProperty = db.GetType().GetProperty(tableName);

                if (dbSetProperty != null)
                {
                    var dbSet = dbSetProperty.GetValue(db);

                    var firstRecord = ((IEnumerable<object>)dbSet).Cast<dynamic>()
                                            .OrderBy(r => r.Year)
                                            .FirstOrDefault();

                    if (firstRecord != null)
                    {
                        return (int)firstRecord.Year;
                    }
                }

                return 0;
            }
        }
        protected string GetColumnName()
        {
            return this.GetType().Name + "s";
        }
    }
}
