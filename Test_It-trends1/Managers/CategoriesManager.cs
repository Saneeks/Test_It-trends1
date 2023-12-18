using Test_It_trends1.Models;

namespace Test_It_trends1.Managers
{
    public class CategoriesManager
    {
        private readonly Context db;
        
        public CategoriesManager(Context context)
        {
            db = context ?? throw new ArgumentNullException(nameof(db));
        }

        public void Create(Category category)
        {
            if (category == null)
                throw new ArgumentException(nameof(category));

            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Category category = db.Categories.SingleOrDefault(x => x.Id == id); // Single вместо First даёт возможность отловить дубли
            if (category == null) 
                return; //Нельзя удалить, то чего нет
            db.Categories.Remove(category);
            db.SaveChanges();
        }
        public Category GetByID(int id)
        {
            Category category = db.Categories.SingleOrDefault(x => x.Id == id);
            if (category == null)
                return null; // ИЛИ NOT FOUND?
            return category;

        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
    }
}
