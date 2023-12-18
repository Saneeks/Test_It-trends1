using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Models
{
    public class Article // Сущность новостей
    {
        public int Id { get; set; } // PK
        [Display(Name = "Название статьи")]
        [Required(ErrorMessage = "Введите название статьи")]
        public string Title { get; set; }
        [Display(Name = "Текст статьи")]
        [Required(ErrorMessage = "Статья не должна быть пустая")]
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Views { get; set; }
        public int AuthorId { get; set; } // FK
        public int CategoryId { get; set; } // FK

        // Вне таблицы
        public Author Author { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; } = new();

    }
}
