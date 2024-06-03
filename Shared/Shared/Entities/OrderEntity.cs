using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shared.Entities;

public class OrderEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid OrderId { get; set; } = Guid.NewGuid();

    [BsonElement("customerId")]
    [BsonRepresentation(BsonType.String)]
    public Guid CustomerId { get; set; }

    [BsonElement("orderDate")]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [BsonElement("orderItems")]
    public List<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();

    [BsonIgnore]
    public decimal OrderTotalAmount => OrderItems.Sum(item => item.TotalPrice);
}

