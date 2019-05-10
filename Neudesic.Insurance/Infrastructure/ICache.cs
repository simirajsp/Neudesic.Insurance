using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Infrastructure
{
    public interface ICache
    {
        /// <summary>
        /// Method to get an item from cache
        /// If it doesnot exist in cache, it will load from persistance medium
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">Key to be used in caching</param>
        /// <param name="actualMethod">Delegate that can fetch the item if it does not exist</param>
        /// <returns></returns>
        T Get<T>(string cacheKey, Func<T> actualMethod);

        /// <summary>
        /// Method to get item from cache. Will return default(T) if not found in cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        T Get<T>(string cacheKey);

        /// <summary>
        /// Method to add new item to cache
        /// This will overwrite if item with same key exists
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        void Add(string cacheKey, object value);

        /// <summary>
        /// Method to remove an item from cache
        /// </summary>
        /// <param name="cacheKey">Key using which the item is cached</param>
        void Remove(string cacheKey);
    }
}
