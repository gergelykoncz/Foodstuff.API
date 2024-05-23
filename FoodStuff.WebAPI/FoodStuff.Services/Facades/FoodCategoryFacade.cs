using FoodStuff.Data.Entities;
using FoodStuff.Data.Repositories;
using FoodStuff.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace FoodStuff.Services.Facades
{
    public class FoodCategoryFacade : IFoodCategoryFacade
    {
        private readonly IRepository<FoodCategory> _foodCategoryRepository;

        public FoodCategoryFacade(IRepository<FoodCategory> foodCategoryRepository)
        {
            _foodCategoryRepository = foodCategoryRepository;
        }

        public async Task<IEnumerable<FoodCategoryDto>> GetCategories()
        {
            IEnumerable<FoodCategory> result = await _foodCategoryRepository.GetAll().ToListAsync();
            return result.Select(x => new FoodCategoryDto(x.Id, x.Name));
        }
    }
}
