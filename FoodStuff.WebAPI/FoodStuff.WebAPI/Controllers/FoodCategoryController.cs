using FoodStuff.Services.Dto;
using FoodStuff.Services.Facades;
using FoodStuff.Services.Providers;
using Microsoft.AspNetCore.Mvc;

namespace FoodStuff.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryFacade _facade;
        private readonly ICacheProvider _cacheProvider;

        public FoodCategoryController(IFoodCategoryFacade facade, ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
            _facade = facade;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<IEnumerable<FoodCategoryDto>> Get()
        {
            var result = await _cacheProvider.GetFromCache<IEnumerable<FoodCategoryDto>>("categories");
            if (result == null)
            {
                result = await _facade.GetCategories();
                await _cacheProvider.AddToCache("categories", result);
            }

            return result;
        }
    }
}
