using FoodStuff.Data.Entities;
using FoodStuff.Data.Repositories;
using FoodStuff.Services.Dto;
using FoodStuff.Services.Facades;
using FoodStuff.UnitTests.Utils;
using Moq;
using System.Linq.Expressions;

namespace FoodStuff.UnitTests.Services.Facades
{
    public class FoodFacadeTests
    {
        [Test]
        public async Task GetFoodsByCategory_Should_Return_Page()
        {
            var data = new List<Food>() {
                new Food(){Id=1, Name="Test Food 1", Ingredients = "", FoodCategoryId = 1 },
                new Food(){Id=2, Name="Test Food 2", Ingredients = "", FoodCategoryId = 2 }
            };

            Mock<IRepository<Food>> repositoryMock = mockRepository(data);

            FoodFacade sut = new FoodFacade(repositoryMock.Object);
            PageableFoodDto result = await sut.GetFoodsByCategory(2, 0, 10);
            Assert.AreEqual(result.Foods.ElementAt(0).Name, "Test Food 2");
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.CurrentPage, 0);
        }

        [Test]
        public async Task GetFoodsBySearchTerm_Should_Return_Page()
        {
            var data = new List<Food>() {
                new Food(){Id=1, Name="Test Food 1", Ingredients = "", FoodCategoryId = 1 },
                new Food(){Id=2, Name="Test Food 2", Ingredients = "", FoodCategoryId = 2 }
            };

            Mock<IRepository<Food>> repositoryMock = mockRepository(data);

            FoodFacade sut = new FoodFacade(repositoryMock.Object);
            PageableFoodDto result = await sut.GetFoodsBySearchTerm("1", 0, 10);
            Assert.AreEqual(result.Foods.ElementAt(0).Name, "Test Food 1");
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.CurrentPage, 0);
        }

        private Mock<IRepository<Food>> mockRepository(IEnumerable<Food> expectedData)
        {
            Mock<IRepository<Food>> repositoryMock = new Mock<IRepository<Food>>();
            repositoryMock.Setup(x => x.Filter(It.IsAny<Expression<Func<Food, bool>>>())).Returns<Expression<Func<Food, bool>>>(x => new TestDbAsyncEnumerable<Food>(expectedData.AsQueryable().Where(x)));
            return repositoryMock;
        }
    }
}
