using Test_It_trends1.Models;

namespace Test_It_trends1.Managers
{
    public class AuthorsManager
    {
        private readonly Context db;
        
        public AuthorsManager(Context context)
        {
            db = context ?? throw new ArgumentNullException(nameof(db));
        }

        public void Create(Author author)
        {
            if (author == null)
                throw new ArgumentException(nameof(author));

            db.Authors.Add(author);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Author author = db.Authors.SingleOrDefault(x => x.Id == id); // Single вместо First даёт возможность отловить дубли
            if (author == null) 
                return; //Нельзя удалить, то чего нет
            db.Authors.Remove(author);
            db.SaveChanges();
        }
        public Author GetByID(int id)
        {
            Author author = db.Authors.SingleOrDefault(x => x.Id == id);
            if (author == null)
                return null; // ИЛИ NOT FOUND?
            return author;

        }
        public List<Author> GetAll()
        {
            return db.Authors.ToList();
        }
    }
}
