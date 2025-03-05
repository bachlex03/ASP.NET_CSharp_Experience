using DB.Mongo.Domain.Abstractions;
using MongoDB.Bson;

namespace DB.Mongo.Domain;

public class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTime CreateAt => Id.CreationTime;
}
