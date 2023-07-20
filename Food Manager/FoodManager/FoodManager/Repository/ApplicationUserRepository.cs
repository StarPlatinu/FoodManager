using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly FoodManagerDBContext _db;

		public ApplicationUserRepository(FoodManagerDBContext db) : base(db)
		{
			_db = db;
		}

	}
}
