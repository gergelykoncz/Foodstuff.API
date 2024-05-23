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
            var dbResult = await _foodCategoryRepository.GetAll().Include(c => c.Foods).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Foods.Count
            }).ToListAsync();

            return dbResult.Select(x => new FoodCategoryDto { Id = x.Id, Name = x.Name, Count = x.Count });

        }
    }
}
