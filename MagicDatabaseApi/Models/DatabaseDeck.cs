using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class DatabaseDeck
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("Name")]
        public String Name { get; set; }

        [BsonElement("Commander")]
        public DatabaseCard Commander { get; set; }

        [BsonElement("DateCreated")]
        public String DateCreated { get; set; }

        [BsonElement("AuthorId")]
        public String AuthorId { get; set; }

        [BsonElement("Cards")]
        public List<DatabaseCard> Cards { get; set; }
    }
}
