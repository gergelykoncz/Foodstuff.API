using FoodStuff.Services.Dto;
using FoodStuff.Services.Facades;
using FoodStuff.Services.Providers;
using Microsoft.AspNetCore.Mvc;

namespace FoodStuff.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodFacade _facade;
        private readonly ICacheProvider _cacheProvider;

        public FoodController(IFoodFacade facade, ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
            _facade = facade;
        }

        [HttpGet(Name = "GetFoodsByCategoryId")]
        public async Task<PageableFoodDto> Get(int categoryId, int page = 0, int pageSize = 10)
        {
            string cacheKey = $"foods:{categoryId}:{page}:{pageSize}";
            return await _cacheProvider.AddToCacheIfNotExistsThenReturnIt<PageableFoodDto>(cacheKey, () => _facade.GetFoodsByCategory(categoryId, page, pageSize));
        }
    }
}
