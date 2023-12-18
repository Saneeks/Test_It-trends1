using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Models
{
    public class Comment
    {
        public int Id { get; set; } // PK
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        public int ArticleId { get; set; }

        // Вне таблицы
        public Article Article { get; set; }

    }
}
