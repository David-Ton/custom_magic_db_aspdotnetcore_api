using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class Creature
    {
       
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("CMC")]
        public int CMC { get; set; }

        [BsonElement("Cost")]
        public string Cost { get; set; }

        [BsonElement("Types")]
        public List<string> Types { get; set; }

        [BsonElement("Subtypes")]
        public List<string> Subtypes { get; set; }

        [BsonElement("Keywords")]
        public List<string> Keywords { get; set; }

        [BsonElement("Power")]
        public int Power { get; set; }

        [BsonElement("Toughness")]
        public int Toughness { get; set; }
    }
}
