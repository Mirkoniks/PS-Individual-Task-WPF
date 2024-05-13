using Data.Attributes;
using Data.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Record : BaseModel<Record>, ISerachable<Record,SearchRecordDTO>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
        public string Topic { get; set; }
        public string SubTopic { get; set; }
        public string Product { get; set; }


        public bool Create(Record record)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Records.Add(record);

                return db.SaveChanges() > 0;
            }
        }

        public List<Record> SearchRecords(SearchRecordDTO SerachDto)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = SerachByYear(int.Parse(SerachDto.Year), GetColumnName())
                    .Where(record => (string.IsNullOrEmpty(SerachDto.Title) || record.Title.Contains(SerachDto.Title)) &&
                    (string.IsNullOrEmpty(SerachDto.Description) || record.Description.Contains(SerachDto.Description)) &&
                    (string.IsNullOrEmpty(SerachDto.Author) || record.Author.Contains(SerachDto.Author)) &&
                    (string.IsNullOrEmpty(SerachDto.Topic) || record.Topic.Contains(SerachDto.Topic)) &&
                    (string.IsNullOrEmpty(SerachDto.SubTopic) || record.SubTopic.Contains(SerachDto.SubTopic)) &&
                    (string.IsNullOrEmpty(SerachDto.Product) || record.Product.Contains(SerachDto.Product)) &&
                    (string.IsNullOrEmpty(SerachDto.Keyword1) || record.Description.Contains(SerachDto.Keyword1)) &&
                    (string.IsNullOrEmpty(SerachDto.Keyword2) || record.Description.Contains(SerachDto.Keyword2))
                )
                .ToList();

                    if (result.Count == 0) 
                    {
                        result = db.Records
                                  .Where(r => r.Year <= int.Parse(SerachDto.Year))
                                  .GroupBy(r => r.Author)
                                  .Select(g => g.OrderByDescending(r => r.Year).FirstOrDefault())
                                  .ToList(); 
                    }
                
                return result.OrderByDescending(r => r.Year).ToList();
            }
        }
    }
}
