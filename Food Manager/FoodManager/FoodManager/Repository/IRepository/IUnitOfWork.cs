namespace FoodManager.Repository.IRepository
{
    public interface IUnitOfWork  : IDisposable
    {
        ICategoryRepository Category { get; }
        IFoodTypeRepository FoodType { get; }
        IMenuItemRepository MenuItem { get; }
        public IShoppingCartRepository ShoppingCart { get;}
        void Save();
    }
}
