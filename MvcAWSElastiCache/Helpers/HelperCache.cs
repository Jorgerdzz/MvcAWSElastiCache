using StackExchange.Redis;

namespace MvcAWSElastiCache.Helpers
{
    public class HelperCache
    {
        private static Lazy<ConnectionMultiplexer>
            CreateConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string connectionString = @"cache-coches.tltuaq.ng.0001.use1.cache.amazonaws.com:6379";
                return ConnectionMultiplexer.Connect(connectionString);
            });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return CreateConnection.Value;
            }
        }
    }
}
