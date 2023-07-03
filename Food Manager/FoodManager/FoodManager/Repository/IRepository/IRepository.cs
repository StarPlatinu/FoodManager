using System.Linq.Expressions;

namespace FoodManager.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //GET ALL, GET By ID FIRST OR DEFAULT, ADD, REMOVE, REMOVERANGE
        void Add(T entity);
       void Remove(T entity);
       void RemoveRange(IEnumerable<T> entities);

       IEnumerable<T> GetAll();

       T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);


    }
}
