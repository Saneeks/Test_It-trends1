using Microsoft.EntityFrameworkCore;
using Test_It_trends1.Models;

namespace Test_It_trends1.Managers
{
    public class ArticlesManager
    {
        private readonly Context db;

        public ArticlesManager(Context context)
        {
            db = context ?? throw new ArgumentNullException(nameof(db));
        }

        public void Create(string title, string text, int categoryId, int authorId)
        {
            if (title == null || text == null)
                throw new ArgumentException(nameof(title));

            var categoryExists = db.Categories
                .AsNoTracking()
                .Any(x => x.Id == categoryId);
            var authorExists = db.Authors
                .AsNoTracking()
                .Any(x => x.Id == authorId);

            if (!categoryExists || !authorExists)
                throw new Exception($"Название или содержание статьи пустое");

            db.Articles.Add(new Article
            {
                Title = title,
                Text = text,
                Time = DateTimeOffset.Now,
                CategoryId = categoryId,
                AuthorId = authorId,
                Views = 0,
            });
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Article article = db.Articles.SingleOrDefault(x => x.Id == id); // Single вместо First даёт возможность отловить дубли
            if (article == null)
                return; // Нельзя удалить, то чего нет
            db.Articles.Remove(article);
            db.SaveChanges();
        }
        public Article GetByID(int id)
        {
            
            

            Article article = db.Articles
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .SingleOrDefault(x => x.Id == id);
            article.Views++;
            db.Update(article);
            db.SaveChanges();
            return article;
        }
        public List<Article> GetAll()
        {
            return db.Articles
                .Include (x => x.Category)
                .Include(x => x.Author)
                .AsNoTracking()
                .ToList();
        }
    }
}
