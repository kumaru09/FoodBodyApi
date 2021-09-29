namespace FoodbodyApi.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
        public string MongoConnectionString { get; set; }
        public string BlobConnectionString { get; set; }
    }

    public interface IDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ProductCollectionName { get; set; }
        string MongoConnectionString { get; set; }
        string BlobConnectionString { get; set; }
    }
}
