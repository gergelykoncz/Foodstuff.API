using FoodStuff.Services.Dto;

namespace FoodStuff.Services.Facades
{
    public interface IFoodFacade
    {
        Task<PageableFoodDto> GetFoodsByCategory(int categoryId, int page, int pageSize);
    }
}
