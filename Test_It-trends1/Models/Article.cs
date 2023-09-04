using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Models
{
    public class Article // Сущность новостей
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Views { get; set; }
        public List<Comment> Comments { get; set; } = new();

    }
}
