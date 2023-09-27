using Microsoft.EntityFrameworkCore;
using Test_It_trends1.Models;

namespace Test_It_trends1.Managers
{
    public class AuthorsManager
    {
        private readonly Context db;
        public AuthorsManager(Context context)
        {
            db = context;
        }
        Author CreateAuthor(Author author)
        {
            if (author == null)
                return null; //КАКАЯ ОШИБКА?
            db.Authors.Add(author);
            db.SaveChanges();
            return author; // ???
        }
        void DeleteAuthorByID(int id)
        {
            Author author = db.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null) ;
            db.Authors.Remove(author);
            db.SaveChanges();
        }
        Author GetAuthorByID(int id)
        {
            Author author = db.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
                return null; // ИЛИ NOT FOUND?
            return author;

        }
        List<Author> GetAuthors()
        {
            return db.Authors.ToList();
        }
    }
}
