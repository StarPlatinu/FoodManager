using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
	public class OrderDetailRepository : Repository<OrderDetails>, IOrderDetailRepository
	{
		private readonly FoodManagerDBContext _db;

		public OrderDetailRepository(FoodManagerDBContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderDetails obj)
		{
			_db.OrderDetails.Update(obj);
		}
	}
}
