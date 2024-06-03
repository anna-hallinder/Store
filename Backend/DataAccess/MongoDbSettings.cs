namespace DataAccess;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty; //Anslutningssträngen
    public string DatabaseName { get; set; } = string.Empty; //Databasnamnet
}