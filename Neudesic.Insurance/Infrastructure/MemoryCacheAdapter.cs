using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Infrastructure
{
    public class MemoryCacheAdapter : ICache
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public MemoryCacheAdapter(IMemoryCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        public void Add(string cacheKey, object value)
        {
            // Using absolute expiration as we want the cache to expire after configured minutes
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(GetCacheExpiryMinutes())
            };
            
            _cache.Set(cacheKey, value);
        }

        public T Get<T>(string cacheKey, Func<T> actualMethod)
        {
            return _cache.GetOrCreate(cacheKey, entry =>
             {
                 entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(GetCacheExpiryMinutes());
                 return actualMethod();
             });
        }

        public T Get<T>(string cacheKey)
        {
            return _cache.Get<T>(cacheKey);
        }

        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        private int GetCacheExpiryMinutes()
        {
            return _configuration.GetSection("Caching").GetValue<int>("AbsoluteExpiryInMinutes");
        }
    }
}
