using FoodbodyApi.Models;
using MongoDB.Driver;

namespace FoodbodyApi.Services
{
    public class MongoService
    {
        private static MongoClient _client;

        public MongoService(IDatabaseSettings settings)
        {
            _client = new MongoClient(settings.MongoConnectionString);
        }

        public MongoClient GetClient()
        {
            return _client;
        }
    }
}