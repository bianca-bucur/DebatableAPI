using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DebatableAPI.Models
{
  public class Comment
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("createdBy")]
    public string CreatedBy { get; set; }

    [BsonElement("content")]
    public string Content { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; }
  }
}
