using FoodStuff.Services.Providers;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Newtonsoft.Json;
using System.Text;

namespace FoodStuff.UnitTests.Services.Providers
{
    internal class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class CacheProviderTests
        {
            private TestObject _testObject = null;
            private byte[] _expectedBytes = null;

            [SetUp]
            public void SetUp()
            {
                _testObject = new TestObject() { Id = 1, Name = "Test" };
                _expectedBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_testObject));
            }

            [Test]
            public async Task AddToCache_Should_Serialize_And_Add_To_Cache()
            {
                Mock<IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                var cacheProvider = new CacheProvider(cacheMock.Object);

                await cacheProvider.AddToCache<TestObject>("key", _testObject);

                cacheMock.Verify(x => x.SetAsync("key", _expectedBytes, It.IsAny<DistributedCacheEntryOptions>(), It.IsAny<CancellationToken>()));
            }

            [Test]
            public async Task GetFromCache_Should_Return_Null_When_Value_Is_Not_In_Cache()
            {
                Mock<IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                var cacheProvider = new CacheProvider(cacheMock.Object);
                var result = await cacheProvider.GetFromCache<TestObject>("key");
                Assert.IsNull(result);
            }

            [Test]
            public async Task GetFromCache_Should_Cached_Value_When_Exists()
            {
                Mock<IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                cacheMock.Setup(x => x.GetAsync("key", It.IsAny<CancellationToken>())).Returns(Task.FromResult(_expectedBytes));
                var cacheProvider = new CacheProvider(cacheMock.Object);
                
                var result = await cacheProvider.GetFromCache<TestObject>("key");
                Assert.AreEqual(_testObject.Id, result.Id);
                Assert.AreEqual(_testObject.Name, result.Name);
            }

            [Test]
            public async Task GetFromCache_Should_Not_Fail_For_Invalid_Object()
            {
                var invalidBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject("new object") );

                Mock <IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                cacheMock.Setup(x => x.GetAsync("key", It.IsAny<CancellationToken>())).Returns(Task.FromResult(invalidBytes));
                var cacheProvider = new CacheProvider(cacheMock.Object);

                var result = await cacheProvider.GetFromCache<TestObject>("key");
                Assert.IsNull(result);
                cacheMock.Verify(x => x.RemoveAsync("key", It.IsAny<CancellationToken>()));
            }

            [Test]
            public async Task RemoveFromCache_Should_Call_Remove()
            {
                Mock<IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                var cacheProvider = new CacheProvider(cacheMock.Object);

                await cacheProvider.RemoveFromCache("key");

                cacheMock.Verify(x => x.RemoveAsync("key", It.IsAny<CancellationToken>()));
            }

            [Test]
            public async Task AddToCacheIfNotExistsThenReturnIt_Should_Add_And_Return()
            {
                Mock<IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                var cacheProvider = new CacheProvider(cacheMock.Object);

                var result = await cacheProvider.AddToCacheIfNotExistsThenReturnIt<TestObject>("key", () => Task.FromResult(_testObject));

                cacheMock.Verify(x => x.SetAsync("key", _expectedBytes, It.IsAny<DistributedCacheEntryOptions>(), It.IsAny<CancellationToken>()));

                Assert.AreEqual(_testObject.Id, result.Id);
                Assert.AreEqual(_testObject.Name, result.Name);
            }

            [Test]
            public async Task AddToCacheIfNotExistsThenReturnIt_Should_Return_If_Exists()
            {
                Mock<IDistributedCache> cacheMock = new Mock<IDistributedCache>();
                var cacheProvider = new CacheProvider(cacheMock.Object);

                cacheMock.Setup(x => x.GetAsync("key", It.IsAny<CancellationToken>())).Returns(Task.FromResult(_expectedBytes));

                var result = await cacheProvider.AddToCacheIfNotExistsThenReturnIt<TestObject>("key", () => Task.FromResult(_testObject));

                cacheMock.Verify(x => x.SetAsync("key", It.IsAny<byte[]>(), It.IsAny<DistributedCacheEntryOptions>(), It.IsAny<CancellationToken>()), Times.Never());

                Assert.AreEqual(_testObject.Id, result.Id);
                Assert.AreEqual(_testObject.Name, result.Name);
            }
        }
    }
}
