using MongoDB.Driver;
using TestCSharp.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Plant> Plants => _database.GetCollection<Plant>("plants");
    public IMongoCollection<Department> Departments => _database.GetCollection<Department>("departments");
    public IMongoCollection<Position> Positions => _database.GetCollection<Position>("positions");
    public IMongoCollection<User> Users => _database.GetCollection<User>("users");
}
