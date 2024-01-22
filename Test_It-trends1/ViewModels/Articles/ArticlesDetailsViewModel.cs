using System.ComponentModel.DataAnnotations;
using Test_It_trends1.Models;

namespace Test_It_trends1.ViewModels
{
    public class ArticlesDetailsViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Views { get; set; }
        public List<Comment> Comments { get; set; }
        [Display(Name = "Введите комментарий")]
        [Required(ErrorMessage = "Комментарий не должен быть пустым")]
        public string NewCommentText { get; set; }

        public ArticlesDetailsViewModel(Article article, List<Comment> comments)
        {
            Id = article.Id;
            Title = article.Title;
            Text = article.Text;
            Time = article.Time;
            Views = article.Views;

            Comments = comments.Select(x => new Comment
            {
                Id = x.Id,
                Text = x.Text,
                Time = x.Time,
            }).ToList();
        }
        public ArticlesDetailsViewModel() { }
    }
}
