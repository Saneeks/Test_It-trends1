using System.ComponentModel.DataAnnotations;
using Test_It_trends1.Models;

namespace Test_It_trends1.ViewModels
{
    public class ArticlesCreateViewModel
    {
        [Display(Name = "Название статьи")]
        [Required(ErrorMessage = "Введите название статьи")]
        public string Title { get; set; }
        [Display(Name = "Текст статьи")]
        [Required(ErrorMessage = "Статья не должна быть пустая")]
        public string Text { get; set; }
        [Display(Name = "Автор статьи")]
        [Required(ErrorMessage = "Выберите автора статьи")]
        public int AuthorId { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Выберите категорию для статьи")]
        public int CategoryId { get; set; } 

        public List<Author> Authors { get; set; } = new();
        public List<Category> Categories { get; set; } = new();

    }
}
