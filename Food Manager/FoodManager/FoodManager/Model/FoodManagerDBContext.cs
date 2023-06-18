using Microsoft.EntityFrameworkCore;

namespace FoodManager.Model
{
    public class FoodManagerDBContext : DbContext
    {
        public FoodManagerDBContext(DbContextOptions<FoodManagerDBContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }   
    }
}
