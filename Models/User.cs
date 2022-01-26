using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace DebatableAPI.Models
{
  public class User
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("username")]
    public string Username { get; set; }
    [BsonElement("password")]
    public string Password { get; set; }
    [BsonElement("nickname")]
    public string Nickname { get; set; }

    [BsonElement("email")]
    [EmailAddressAttribute]
    public string Email { get; set; }

    [BsonElement("points")]
    public int Points { get; set; }

    [BsonElement("role")]
    public Role Role { get; set; }
  }
}
