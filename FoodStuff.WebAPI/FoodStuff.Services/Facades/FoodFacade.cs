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

        public async Task<PageableFoodDto> GetFoodsByCategory(int categoryId, int page, int pageSize)
        {
            int validPage = Math.Max(0, page);
            var count = _repository.Filter(x => x.FoodCategoryId == categoryId).Count();
            var result = await _repository.Filter(x => x.FoodCategoryId == categoryId).Skip(validPage * pageSize).Take(pageSize).ToListAsync();
            return
                new PageableFoodDto()
                {
                    Foods = result.Select(x => new FoodDto() { Id = x.Id, Name = x.Name, Ingredients = x.Ingredients }),
                    Count = count,
                    CurrentPage = page
                };
        }
    }
}
