using MongoDB.Driver;

namespace SortTest.Test
{
    public class MongoDBClient
    {
        private static IMongoDatabase _db;
        private static MongoDBClient _instance;

        public static MongoDBClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MongoDBClient();
                return _instance;
            }
        }

        private MongoDBClient()
        {
            // 1️⃣ Читаємо змінні середовища Railway
            var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION");
            var dbName = Environment.GetEnvironmentVariable("MONGO_DB");

            // 2️⃣ Якщо не налаштовано – падати НЕ БУДЕ, а покаже помилку
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Environment variable MONGO_CONNECTION is not set");

            if (string.IsNullOrWhiteSpace(dbName))
                dbName = "Restaurant";

            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _db.GetCollection<T>(name);
    }
}
