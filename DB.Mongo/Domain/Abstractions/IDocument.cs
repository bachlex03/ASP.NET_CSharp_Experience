using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DB.Mongo.Domain.Abstractions;

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }

    DateTime CreateAt { get; }
}
