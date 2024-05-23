using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FoodStuff.Services.Providers
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _cache;

        public CacheProvider(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task AddToCache<T>(string cacheKey, T value) where T : class
        {
            var serialized = JsonConvert.SerializeObject(value);
            await _cache.SetStringAsync(cacheKey, serialized);
        }

        public async Task<T> GetFromCache<T>(string cacheKey) where T : class
        {
            var response = await _cache.GetStringAsync(cacheKey);
            if (response == null)
            {
                return null;
            }

            T result = null;

            try
            {
                result = JsonConvert.DeserializeObject<T>(response);
            }
            catch 
            {
                await RemoveFromCache(cacheKey);
            }
            return result;
        }

        public async Task RemoveFromCache(string cacheKey)
        {
            await _cache.RemoveAsync(cacheKey);
        }
    }
}
