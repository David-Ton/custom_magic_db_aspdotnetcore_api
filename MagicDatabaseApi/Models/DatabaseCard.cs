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
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("cmc")]
        public int cmc { get; set; }

        [BsonElement("manaCost")]
        public string manaCost { get; set; }

        [BsonElement("colorIdentity")]
        public List<String> colorIdentity { get; set; }

        [BsonElement("types")]
        public List<string> types { get; set; }

        [BsonElement("subtypes")]
        public List<string> subtypes { get; set; }

        [BsonElement("rarity")]
        public String rarity { get; set; }

        [BsonElement("set")]
        public String set { get; set; }

        [BsonElement("setName")]
        public String setName { get; set; }

        [BsonElement("loyalty")]
        public int loyalty { get; set; }

        [BsonElement("power")]
        public int power { get; set; }

        [BsonElement("toughness")]
        public int toughness { get; set; }

        [BsonElement("text")]
        public String text { get; set; }

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
