using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Models
{
    public class Category
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }

        // Вне таблицы
        public List<Article> Articles { get; set; } = new();
    }
}
