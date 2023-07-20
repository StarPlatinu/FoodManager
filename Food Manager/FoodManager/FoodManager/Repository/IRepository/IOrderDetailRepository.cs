using FoodManager.Model;

namespace FoodManager.Repository.IRepository
{
	public interface IOrderDetailRepository : IRepository<OrderDetails>
	{
		void Update(OrderDetails obj);
	}
}
