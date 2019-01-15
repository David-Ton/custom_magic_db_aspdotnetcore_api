using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MagicDatabaseApi.Models
{
    public class DatabaseUser
    {
        public ObjectId id { get; set; }

        [BsonElement("UserId")]
        public String UserId { get; set; }

        [BsonElement("Email")]
        public String Email { get; set; }

        [BsonElement("Decks")]
        public List<ObjectId> Decks { get; set; }
    }
}
