﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using VueAdmin.Common.Extensions;
using VueAdmin.Domain.Shared;

namespace VueAdmin.Application.Caching
{
    public static class VueAdminApplicationCachingExtensions
    {
        /// <summary>
        /// 获取或添加缓存
        /// </summary>
        /// <typeparam name="TCacheItem"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static async Task<TCacheItem> GetOrAddAsync<TCacheItem>(this IDistributedCache cache, string key, Func<Task<TCacheItem>> factory, int minutes)
        {
            TCacheItem cacheItem;

            var result = await cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(result))
            {
                cacheItem = await factory.Invoke();

                var options = new DistributedCacheEntryOptions();
                if (minutes != VueAdminConsts.CacheStrategy.NEVER)
                {
                    options.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minutes);
                }

                await cache.SetStringAsync(key, cacheItem.ToJson(), options);
            }
            else
            {
                cacheItem = result.FromJson<TCacheItem>();
            }

            return cacheItem;
        }
    }
}
