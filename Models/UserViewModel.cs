using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using TestCSharp.ViewModels;
using TestCSharp.Models;

namespace TestCSharp.ViewModels
{
    public class UserViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Plant { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IEnumerable<Plant> Plants { get; set; } = new List<Plant>();
        public IEnumerable<Department> Departments { get; set; } = new List<Department>();
        public IEnumerable<Position> Positions { get; set; } = new List<Position>();
    }
}
