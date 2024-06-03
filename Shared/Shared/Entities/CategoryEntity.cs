using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shared.Entities;

public class CategoryEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid CategoryId { get; set; } = Guid.NewGuid();

    [BsonElement("name")]
    public string CategoryName { get; set; } = null!;
}