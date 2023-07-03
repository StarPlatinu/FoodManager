using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
       private readonly FoodManagerDBContext _dbContext;

        public MenuItemRepository(FoodManagerDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(MenuItem item)
        {
            var objFromDb = _dbContext.MenuItem.FirstOrDefault(u=>u.Id == item.Id);
            objFromDb.Name=item.Name;
            objFromDb.Description=item.Description;
            objFromDb.Price=item.Price;
            objFromDb.CategoryId=item.CategoryId;
            objFromDb.FoodTypeId=item.FoodTypeId;
            if (objFromDb.Image != null)
            {
                objFromDb.Image = item.Image;
            }
        }
    }
}
