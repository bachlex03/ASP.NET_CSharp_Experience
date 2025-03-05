using MongoDB.Bson.Serialization.Attributes;

namespace DB.Mongo.Domain.Products;

[BsonCollection("Products")]
public class Product : Document
{
    [BsonElement("name")]
    public string Name { get; set; } = default!;

    [BsonElement("description")]
    public string Description { get; set; } = default!;

    [BsonElement("price")]
    public decimal Price { get; set; }
}
