namespace FoodStuff.Services.Dto
{
    public class PageableFoodDto
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public IEnumerable<FoodDto> Foods { get; set; }
    }
}
