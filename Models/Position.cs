using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace TestCSharp.Models
{
    public class Position
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; } = string.Empty;       
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Plant { get; set; } = string.Empty;
    }
}
