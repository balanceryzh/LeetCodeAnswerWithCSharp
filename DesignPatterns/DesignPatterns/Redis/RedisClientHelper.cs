using CSRedis;
using System.Collections.Concurrent;


namespace DesignPatterns.Redis
{
   public class RedisClientHelper
    {
        static ConcurrentDictionary<string, CSRedisClient> clients = new ConcurrentDictionary<string, CSRedisClient>();

        /// <summary>
        /// 获取Redis客户端
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CSRedisClient GetRedis(string conntectionString)
        {
            if (string.IsNullOrWhiteSpace(conntectionString))
            {
                return clients.Count > 0 ? clients.ToArray()[0].Value : null;
            }

            CSRedisClient client = null;
            clients.TryGetValue(conntectionString, out client);

            if (client == null)
            {
                client = new CSRedisClient(conntectionString);
                clients.TryAdd(conntectionString, client);
            }

            return client;
        }

    }
}
