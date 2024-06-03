using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities;

public class CustomerEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid CustomerId { get; set; } = Guid.NewGuid();

    [BsonElement("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [BsonElement("lastName")]
    public string LastName { get; set; } = string.Empty;

    [BsonElement("email")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BsonElement("password")]
    public string Password { get; set; } = string.Empty;

    [BsonElement("phone")]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [BsonElement("address")]
    public string Address { get; set; } = string.Empty;

    [BsonElement("postalCode")]
    public string PostalCode { get; set; } = string.Empty;

    [BsonElement("city")]
    public string City { get; set; } = string.Empty;

    [BsonElement("country")]
    public string Country { get; set; } = string.Empty;

    [BsonIgnore]
    public string FullName => $"{FirstName} {LastName}";

    [BsonElement("orders")]
    public ICollection<Guid> OrderIds { get; set; } = new List<Guid>();
}