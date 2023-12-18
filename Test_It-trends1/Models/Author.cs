
using System.ComponentModel.DataAnnotations;

namespace Test_It_trends1.Models
{
    public class Author
    {
        // [Display(Id = "ID автора")]
        public int Id { get; set; } // PK
        [Display(Name = "Имя автора")]
        [Required (ErrorMessage = "Введите имя автора")]
        public string Name { get; set; }

        // Вне таблицы
        public List<Article> Articles { get; set; } = new ();
    }
}
