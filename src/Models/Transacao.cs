namespace crebito.Models;

using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class Transacao {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Guid { get; set; }
    public int clienteid { get; set; }
    [Required]
    public int valor { get; set; }
    [Required]
    public string? tipo { get; set; }

    [Required]
    [MaxLength(10)]
    [MinLength(1)]
    public string? descricao { get; set; }
    public DateTime realizada_em { get; set; }
}