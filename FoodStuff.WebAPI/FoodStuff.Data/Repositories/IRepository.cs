namespace FoodStuff.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Filter(Func<T, bool> predicate);
        T GetById(int id);
    }
}
