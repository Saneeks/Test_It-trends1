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

        public void CreateAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentException(nameof(author));

            db.Authors.Add(author);
            db.SaveChanges();
        }
        public void DeleteAuthorByID(int id)
        {
            Author author = db.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null) ;
            db.Authors.Remove(author);
            db.SaveChanges();
        }
        public Author GetAuthorByID(int id)
        {
            Author author = db.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
                return null; // ИЛИ NOT FOUND?
            return author;

        }
        public List<Author> GetAuthors()
        {
            return db.Authors.ToList();
        }
    }
}
