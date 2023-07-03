using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly FoodManagerDBContext _dbContext;

        public FoodTypeRepository(FoodManagerDBContext db) : base(db)
        {
            _dbContext = db;
        }

       public void Update(FoodType obj)
        {
            var objFromDb = _dbContext.FoodType.FirstOrDefault(u=>u.Id == obj.Id);
            objFromDb.Name = obj.Name;
        }
    }
}
