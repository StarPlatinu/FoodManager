using Microsoft.EntityFrameworkCore;

namespace FoodManager.Model
{
    public class FoodManagerDBContext : DbContext
    {
        public FoodManagerDBContext(DbContextOptions<FoodManagerDBContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
