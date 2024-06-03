using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shared.Entities;

public class ProductEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid ProductId { get; set; } = Guid.NewGuid();

    [BsonElement("articleNumber")]
    public string ProductArticleNumber { get; set; } = string.Empty;

    [BsonElement("name")]
    public string ProductName { get; set; } = string.Empty;

    [BsonElement("description")]
    public string ProductDescription { get; set; } = string.Empty;

    [BsonElement("unitPrice")]
    public decimal ProductUnitPrice { get; set; }

    [BsonElement("categoryId")]
    [BsonRepresentation(BsonType.String)]
    public Guid CategoryId { get; set; }

    [BsonElement("categoryName")]
    public string CategoryName { get; set; } = string.Empty;

    [BsonElement("status")]
    public string Status { get; set; } = string.Empty;
}