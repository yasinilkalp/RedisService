using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace RedisService.Service
{
    public class RedisServer
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _database;
        private string configurationString;
        private ConfigurationOptions configurationOptions;


        public RedisServer(IConfiguration configuration)
        {
            CreateRedisConfigurationString(configuration);

            _connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            _database = _connectionMultiplexer.GetDatabase(configurationOptions.DefaultDatabase.Value);
        }

        public IDatabase Database => _database;

        public void FlushDatabase()
        {
            _connectionMultiplexer.GetServer(configurationString).FlushDatabase(configurationOptions.DefaultDatabase.Value);
        }

        private void CreateRedisConfigurationString(IConfiguration configuration)
        {
            string host = configuration.GetSection("RedisConfiguration:Host").Value;
            string port = configuration.GetSection("RedisConfiguration:Port").Value;
            string currentDatabaseId = configuration.GetSection("RedisConfiguration:CurrentDatabaseId").Value;
            string ClientName = configuration.GetSection("RedisConfiguration:ClientName").Value;

            configurationString = $"{host}:{port}";

            configurationOptions = new ConfigurationOptions
            {
                EndPoints = { configuration.GetSection("RedisConfiguration")["ConnectionString"] },
                AbortOnConnectFail = false,
                DefaultDatabase = Int32.Parse(currentDatabaseId),
                AllowAdmin = true,
                ClientName = ClientName
            };
        }
    }
}
