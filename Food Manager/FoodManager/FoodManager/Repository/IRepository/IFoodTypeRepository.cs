using FoodManager.Model;

namespace FoodManager.Repository.IRepository
{
    public interface IFoodTypeRepository:IRepository<FoodType>
    {
        void Update(FoodType foodType);
    }
}
