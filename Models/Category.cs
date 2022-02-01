﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DebatableAPI.Models
{
  public class Category
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("topics")]
    public Topic[]? Topics { get; set; }
  }
}
