using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		private readonly FoodManagerDBContext _db;

		public OrderHeaderRepository(FoodManagerDBContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderHeader obj)
		{
			_db.OrderHeader.Update(obj);
		}

		public void UpdateStatus(int id, string status)
		{
			var orderFromDb = _db.OrderHeader.FirstOrDefault(u => u.Id == id);
			if (orderFromDb != null)
			{
				orderFromDb.Status = status;
			}
		}
	}
}
