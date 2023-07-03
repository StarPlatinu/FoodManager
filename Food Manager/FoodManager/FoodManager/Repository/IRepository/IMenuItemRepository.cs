using FoodManager.Model;

namespace FoodManager.Repository.IRepository
{
    public interface IMenuItemRepository:IRepository<MenuItem>
    {
        void Update(MenuItem obj);
    }
}
