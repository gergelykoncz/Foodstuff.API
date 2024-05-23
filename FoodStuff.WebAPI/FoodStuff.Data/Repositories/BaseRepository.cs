using System.Linq.Expressions;

namespace FoodStuff.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly FoodstuffContext _context;

        public BaseRepository(FoodstuffContext context)
        {
            _context = context;
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return _context.Find<T>(id);
        }
    }
}
