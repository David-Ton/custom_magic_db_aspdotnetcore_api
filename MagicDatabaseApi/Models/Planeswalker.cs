using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class Planeswalker
    {

        //[BsonElement("Name")]
        public string Name { get; set; }

        //[BsonElement("CMC")]
        public int CMC { get; set; }

        //[BsonElement("Cost")]
        public string Cost { get; set; }

        //[BsonElement("Types")]
        public List<string> Types { get; set; }

        //[BsonElement("Subtypes")]
        public List<string> Subtypes { get; set; }

        //[BsonElement("Loyalty")]
        public int Loyalty { get; set; }
    }
}
