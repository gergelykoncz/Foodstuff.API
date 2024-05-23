using FoodStuff.Data.Entities;
using FoodStuff.Data.Repositories;
using FoodStuff.Services.Dto;
using FoodStuff.Services.Facades;
using FoodStuff.UnitTests.Utils;
using Moq;

namespace FoodStuff.UnitTests.Services.Facades
{
    public class FoodCategoryFacadeTests
    {
        [Test]
        public async Task GetAll_Should_Return_All_Items_From_Repository()
        {
            var data = new List<FoodCategory>() {
                new FoodCategory(){Id=1, Name="Test Category"}
            }.AsQueryable();

            Mock<IRepository<FoodCategory>> repositoryMock = new Mock<IRepository<FoodCategory>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(new TestDbAsyncEnumerable<FoodCategory>(data));
            
            FoodCategoryFacade sut = new FoodCategoryFacade(repositoryMock.Object);
            IEnumerable<FoodCategoryDto> result = await sut.GetCategories();
            Assert.AreEqual(result.ElementAt(0).Name, "Test Category");
        }
    }
}
