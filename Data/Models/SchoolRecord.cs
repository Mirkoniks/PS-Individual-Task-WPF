using Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SchoolRecord : BaseModel<SchoolRecord>, ISerachable<SchoolRecord, SearchSchoolRecordDTO>
    {
        public string Conspect { get; set; }

        public string Subject { get; set; }

        public bool Create(SchoolRecord record)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.SchoolRecords.Add(record);

                return db.SaveChanges() > 0;
            }
        }

        public List<SchoolRecord> SearchRecords(SearchSchoolRecordDTO SerachDto)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = SerachByYear(int.Parse(SerachDto.Year), GetColumnName())
                    .Where(record => (string.IsNullOrEmpty(SerachDto.Subject) || record.Subject.Contains(SerachDto.Subject)) &&
                    (string.IsNullOrEmpty(SerachDto.Conspect) || record.Conspect.Contains(SerachDto.Conspect)) &&
                    (string.IsNullOrEmpty(SerachDto.Keyword1) || record.Conspect.Contains(SerachDto.Keyword1)) &&
                    (string.IsNullOrEmpty(SerachDto.Keyword2) || record.Conspect.Contains(SerachDto.Keyword2))
                )
                .ToList();

                if (result.Count == 0)
                {
                    result = db.SchoolRecords
                              .Where(r => r.Year <= int.Parse(SerachDto.Year))
                              .GroupBy(r => r.Subject)
                              .Select(g => g.OrderByDescending(r => r.Id).FirstOrDefault())
                              .ToList();
                }

                return result;
            }
        }
    }
}
