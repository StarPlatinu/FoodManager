namespace FoodManager.Repository.IRepository
{
    public interface IUnitOfWork  : IDisposable
    {
        ICategoryRepository Category { get; }
        IFoodTypeRepository FoodType { get; }
        IMenuItemRepository MenuItem { get; }
        public IShoppingCartRepository ShoppingCart { get;}
		IOrderHeaderRepository OrderHeader { get; }
		IOrderDetailRepository OrderDetail { get; }

		IApplicationUserRepository ApplicationUser { get; }
		void Save();
    }
}
