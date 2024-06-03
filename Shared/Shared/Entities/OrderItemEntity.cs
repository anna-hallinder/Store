using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shared.Entities;

public class OrderItemEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid OrderItemId { get; set; } = Guid.NewGuid();

    [BsonElement("orderId")]
    [BsonRepresentation(BsonType.String)]
    public Guid OrderId { get; set; }

    [BsonElement("productId")]
    [BsonRepresentation(BsonType.String)]
    public Guid ProductId { get; set; }

    [BsonElement("productName")]
    public string ProductName { get; set; } = string.Empty;

    [BsonElement("quantity")]
    public int Quantity { get; set; }

    [BsonElement("unitPrice")]
    public decimal UnitPrice { get; set; }

    [BsonIgnore]
    public decimal TotalPrice => Quantity * UnitPrice;
}
