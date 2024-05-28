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
            return await _cacheProvider.AddToCacheIfNotExistsThenReturnIt<IEnumerable<FoodCategoryDto>>("categories", () => _facade.GetCategories());
        }
    }
}
