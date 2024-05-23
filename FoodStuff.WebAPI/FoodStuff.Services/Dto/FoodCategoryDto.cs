namespace FoodStuff.Services.Dto
{
    public class FoodCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FoodCategoryDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
