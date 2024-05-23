using FoodStuff.Services.Dto;

namespace FoodStuff.Services.Facades
{
    public interface IFoodCategoryFacade
    {
        Task<IEnumerable<FoodCategoryDto>> GetCategories();
    }
}
