using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RabbitMQDotNet.MVC.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string FirstName { get; set; }

        [BsonElement("Surname")]
        public string LastName { get; set; }

        [BsonElement("DateOfBirth")]
        public string DateOfBirth { get; set; }
    }
}