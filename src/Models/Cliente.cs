namespace crebito.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Cliente {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Guid { get; set; }
    public int clienteid { get; set; }
    public int limite { get; set; }
    public int saldo { get; set; }
}