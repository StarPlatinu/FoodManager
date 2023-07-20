using FoodManager.Model;

namespace FoodManager.Repository.IRepository
{
	public interface IOrderHeaderRepository : IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);
		void UpdateStatus(int id, string status);
	}
}
