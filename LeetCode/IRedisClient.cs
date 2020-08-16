using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public interface IRedisClient
    {
        string Get(string key);
        void Set(string key, object t, int expiresSec = 0);
        T Get<T>(string key) where T : new();
        Task<string> GetAsync(string key);
        Task SetAsync(string key, object t, int expiresSec = 0);
        Task<T> GetAsync<T>(string key) where T : new();
    }


    public class CustomerRedis : IRedisClient
    {
        public string Get(string key)
        {
            return RedisHelper.Get(key);
        }

        public T Get<T>(string key) where T : new()
        {
            return RedisHelper.Get<T>(key);
        }

        public void Set(string key, object t, int expiresSec = 0)
        {
            RedisHelper.Set(key, t, expiresSec);
        }
        public async Task<string> GetAsync(string key)
        {
            return await RedisHelper.GetAsync(key);
        }

        public async Task<T> GetAsync<T>(string key) where T : new()
        {
            return await RedisHelper.GetAsync<T>(key);
        }
        public async Task SetAsync(string key, object t, int expiresSec = 0)
        {
            await RedisHelper.SetAsync(key, t, expiresSec);

        }
    }
}
