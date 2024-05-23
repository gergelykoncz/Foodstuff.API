using FoodStuff.Data.Entities;
using FoodStuff.Data.Repositories;
using FoodStuff.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace FoodStuff.Services.Facades
{
    public class FoodFacade : IFoodFacade
    {
        private readonly IRepository<Food> _repository;

        public FoodFacade(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodDto>> GetFoodsByCategory(int categoryId, int page, int pageSize)
        {
            var result = await _repository.Filter(x => x.FoodCategoryId == categoryId).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result.Select(x => new FoodDto() { Id = x.Id, Name = x.Name, Ingredients = x.Ingredients });
        }
    }
}
