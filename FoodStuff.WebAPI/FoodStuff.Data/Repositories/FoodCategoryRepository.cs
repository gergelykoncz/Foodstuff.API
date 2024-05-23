using FoodStuff.Data.Entities;

namespace FoodStuff.Data.Repositories
{
    public class FoodCategoryRepository : IRepository<FoodCategory>
    {
        private readonly FoodstuffContext _context;

        public FoodCategoryRepository(FoodstuffContext context)
        {
            this._context = context;
        }

        public IQueryable<FoodCategory> Filter(Func<FoodCategory, bool> predicate)
        {
            return _context.FoodCategories.Where(predicate).AsQueryable();
        }

        public IQueryable<FoodCategory> GetAll()
        {
            return _context.FoodCategories.AsQueryable();
        }

        public FoodCategory GetById(int id)
        {
            return _context.FoodCategories.SingleOrDefault(x => x.Id == id);
        }
    }
}
