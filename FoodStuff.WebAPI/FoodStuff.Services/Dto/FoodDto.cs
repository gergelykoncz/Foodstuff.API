namespace FoodStuff.Services.Dto
{
    public class FoodDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Ingredients { get; set; }
    }
}
