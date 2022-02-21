using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DebatableAPI.Models
{
  public class Topic
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("createdBy")]
    public string CreatedBy { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonElement("debateDeadline")]
    public DateTime DebateDeadline { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonElement("voteDeadline")]
    public DateTime VoteDeadline { get; set; }
    
    [BsonElement("comments")]
    public Comment[]? Comments { get; set; }
  }
}
