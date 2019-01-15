using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class DatabaseCardToClient
    {
        public ObjectId id;

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Data")]
        public object Data { get; set; }
    }
}
