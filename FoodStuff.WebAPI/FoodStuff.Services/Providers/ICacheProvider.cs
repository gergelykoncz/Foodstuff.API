﻿namespace FoodStuff.Services.Providers
{
    public interface ICacheProvider
    {
        Task AddToCache<T>(string cacheKey, T value) where T : class;
        Task<T> GetFromCache<T>(string cacheKey) where T : class;
        Task RemoveFromCache(string cacheKey);

    }
}
