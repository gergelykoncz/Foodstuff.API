using System.Linq.Expressions;

namespace FoodStuff.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        T GetById(int id);
    }
}
