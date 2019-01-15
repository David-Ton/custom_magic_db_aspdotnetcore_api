using MongoDB.Bson;

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class DatabaseCard
    {
        [BsonElement("Type")]
        public string Type { get; set; }

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

        [BsonElement("Rarity")]
        public String Rarity { get; set; }

        [BsonElement("Loyalty")]
        public int Loyalty { get; set; }

        [BsonElement("Power")]
        public int Power { get; set; }

        [BsonElement("Toughness")]
        public int Toughness { get; set; }

        [BsonElement("Text")]
        public String Text { get; set; }

        /*
        public DatabaseCard(Card data)
        {
            Type = data.Type;
            if (data.Type.Equals("Creature"))
            {
                string dataString = JsonConvert.SerializeObject(data.Data);
                Creature creatureData = JsonConvert.DeserializeObject<Creature>(dataString);
                Data = new BsonDocument()
                {
                    {"Name", creatureData.Name},
                    {"Cost", creatureData.Cost },
                    {"CMC", creatureData.CMC },
                    {"Types", new BsonArray(creatureData.Types)},
                    {"Subtypes", new BsonArray(creatureData.Subtypes)},
                    {"Keywords", new BsonArray(creatureData.Keywords) },
                    {"Power", creatureData.Power },
                    {"Toughness", creatureData.Toughness }
                };
            }
            else
            {
                string dataString = JsonConvert.SerializeObject(data.Data);
                Planeswalker planeswalkerData = JsonConvert.DeserializeObject<Planeswalker>(dataString);
                Data = new BsonDocument()
                {
                    {"Name", planeswalkerData.Name },
                    {"Cost", planeswalkerData.Cost },
                    {"CMC", planeswalkerData.CMC },
                    {"Types", new BsonArray(planeswalkerData.Types) },
                    {"Subtypes", new BsonArray(planeswalkerData.Subtypes) },
                    {"Loyalty", planeswalkerData.Loyalty }
                };
            }
        }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Data")]
        public BsonDocument Data { get; set; }
        */
    }
}
