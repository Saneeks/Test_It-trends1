using Microsoft.EntityFrameworkCore;
using System.Data;
using Test_It_trends1.Models;

namespace Test_It_trends1.Managers
{
    public class CommentsManager
    {
        private readonly Context db;

        public CommentsManager(Context context)
        {
            db = context ?? throw new ArgumentNullException(nameof(db));
        }

        public void Create(Comment comment)
        {
            if (comment == null)
                throw new ArgumentException(nameof(comment));
            var articlesExists = db.Articles
                .AsNoTracking() // Должна быть экономна, можно использовать при чтении
                .Any(x => x.Id == comment.ArticleId); // Комментарий обязательно должен быть привязан к существующей статье

            if (!articlesExists)
                throw new Exception($"Статья с id = {comment.ArticleId} не существует.");

            db.Comments.Add(comment);
            db.SaveChanges();
        }
        public void Create(int articleId, string commentText)
        {
            if (articleId == null || commentText == null)
                throw new ArgumentException(nameof(articleId));

            var articlesExists = db.Articles
                .AsNoTracking() 
                .Any(x => x.Id == articleId); // Комментарий обязательно должен быть привязан к существующей статье

            if (!articlesExists)
                throw new Exception($"Статья с id = {articleId} не существует.");

            db.Comments.Add(new Comment
            {
                ArticleId = articleId,
                Text = commentText,
                Time = DateTimeOffset.Now,
            });
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Comment comment = db.Comments.SingleOrDefault(x => x.Id == id); // Single вместо First даёт возможность отловить дубли
            if (comment == null)
                return; // Нельзя удалить, то чего нет
            db.Comments.Remove(comment);
            db.SaveChanges();
        }
        public List<Comment> GetComments(int articleId, bool orderByDesc)
        {
            var comments = db.Comments
                .AsNoTracking()
                .Where(x => x.ArticleId == articleId)
                .ToList();

            if (orderByDesc) // Сортировка комменатриев "Новые", "Старые"
                return comments.OrderByDescending(x => x.Time).ToList();
            return comments.OrderBy(x => x.Time).ToList();
        }
        public Comment GetByID(int id)
        {
            Comment comment = db.Comments.SingleOrDefault(x => x.Id == id);
            if (comment == null)
                return null; // ?
            return comment;

        }
        public List<Comment> GetAll() // В комментариях мелонеобходима
        {
            return db.Comments.ToList();
        }
    }
}
