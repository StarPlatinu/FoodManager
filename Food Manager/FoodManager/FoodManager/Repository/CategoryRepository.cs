using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly FoodManagerDBContext _db;
        public CategoryRepository(FoodManagerDBContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
           var objFromDb = _db.Categories.FirstOrDefault(u=>u.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
