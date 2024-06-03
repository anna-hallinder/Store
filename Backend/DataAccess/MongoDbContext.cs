using MongoDB.Driver;
using Shared.Entities;

namespace DataAccess;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<CategoryEntity> Categories => _database.GetCollection<CategoryEntity>("Categories");
    public IMongoCollection<ProductEntity> Products => _database.GetCollection<ProductEntity>("Products");

    public IMongoCollection<CustomerEntity> Customers => _database.GetCollection<CustomerEntity>("Customers");

    public IMongoCollection<OrderEntity> Orders => _database.GetCollection<OrderEntity>("Orders");


}