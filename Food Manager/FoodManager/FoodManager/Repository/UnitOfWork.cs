using FoodManager.Model;
using FoodManager.Repository.IRepository;

namespace FoodManager.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly FoodManagerDBContext _context;

        public UnitOfWork(FoodManagerDBContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            FoodType = new FoodTypeRepository(_context);
            MenuItem = new MenuItemRepository(_context);
            ShoppingCart = new ShoppingCartRepository(_context);
        }

        public ICategoryRepository Category { get;private set; }
        public IFoodTypeRepository FoodType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set;}
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();  
        }

    }
}
