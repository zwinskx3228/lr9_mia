using MongoDB.Driver;

namespace SortTest.Test;

public class MongoDBClient
{
    private static IMongoDatabase _db;
    private static MongoDBClient _instance;

    public static MongoDBClient Instance
    {
        get => _instance ?? new MongoDBClient();
    }

    private MongoDBClient()
    {
        var connectionString = "mongodb+srv://sasha342008_db_user:sasha342008@cluster0.0itzblg.mongodb.net/?appName=Cluster0";
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase("Restaurant");
    }

    public IMongoCollection<T> GetCollection<T>(string name) => _db.GetCollection<T>(name);
}
