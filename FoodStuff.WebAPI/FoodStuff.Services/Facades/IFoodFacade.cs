using FoodStuff.Services.Dto;

namespace FoodStuff.Services.Facades
{
    public interface IFoodFacade
    {
        Task<IEnumerable<FoodDto>> GetFoodsByCategory(int categoryId, int page, int pageSize);
    }
}
