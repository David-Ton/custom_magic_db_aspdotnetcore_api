using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using MagicDatabaseApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MagicDatabaseApi.Services
{
    public class DbService
    {

        private readonly IMongoDatabase database;

        public DbService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Magicdb"));
            database = client.GetDatabase("MagicDB");
        }
            
        public async Task<List<DatabaseCardToClient>> QueryCards()
        {
            var cardCollection = database.GetCollection<DatabaseCardToClient>("Cards");
            var result = await cardCollection.FindAsync(card => true);

            return result.ToList();
        }

        public async Task<Card> QueryCardByName(string name, string type)
        {
            if (type.Equals("Creature"))
            {
                var cardCollection = database.GetCollection<Creature>("Creatures");
                var result = await cardCollection.FindAsync(card => card.Name.Equals(name));

                var response = new Card();
                response.Type = "Creature";
                response.Data = result.ToList().FirstOrDefault();

                return response;
            }
            else
            {
                var cardCollection = database.GetCollection<Planeswalker>("Planeswalkers");
                var result = await cardCollection.FindAsync(card => card.Name.Equals(name));

                var response = new Card();
                response.Type = "Planeswalker";
                response.Data = result.ToList().FirstOrDefault();

                return response;
            }   
        }

        /*
        public async Task<DatabaseCard> queryCardById(string id)
        {
            IMongoCollection<DatabaseCard> cards = database.GetCollection<DatabaseCard>("Cards");
            var result = await cards.FindAsync<DatabaseCard>(card => (card.id.Equals(new ObjectId(id))));

            return result.ToList().FirstOrDefault();
        }

        public async Task<Card> AddCard(Card card)
        {
            IMongoCollection<DatabaseCard> cards = database.GetCollection<DatabaseCard>("Cards");
            DatabaseCard databaseCard = new DatabaseCard(card);

            await cards.InsertOneAsync(databaseCard);

            return card;
        }

        public async Task<string> ReplaceOneCard(string id, Card card)
        {
            IMongoCollection<DatabaseCard> cards = database.GetCollection<DatabaseCard>("Cards");
            DatabaseCard databaseCard = new DatabaseCard(card);
            databaseCard.id = new ObjectId(id);

            var result = await cards.ReplaceOneAsync(cardDocument => (cardDocument.id.Equals(new ObjectId(id))), databaseCard);
            return result.ToString();
        }
        */

        //---------------------------Begin Deck Functions-----------------------

        public async Task<List<ObjectId>> getDecksByUser(string userId)
        {
            IMongoCollection<DatabaseUser> users = database.GetCollection<DatabaseUser>("Users");
            var result = await users.FindAsync<DatabaseUser>((user) => user.UserId.Equals(userId));
            var selectedUser = result.ToList().FirstOrDefault();

            List<ObjectId> decks = selectedUser.Decks;
            /*
            var decksString = JsonConvert.SerializeObject(decks);
            List<DatabaseDeck> deserializedDecks = JsonConvert.DeserializeObject<List<DatabaseDeck>>(decksString);
            */

            return decks;
        }

        public async Task<DatabaseDeck> getDeckById(ObjectId id)
        {
            IMongoCollection<DatabaseDeck> decks = database.GetCollection<DatabaseDeck>("Decks");
            var result = await decks.FindAsync((deck) => deck.id.Equals(id));

            return result.ToList().FirstOrDefault();
        }

        public async Task<ObjectId> createDeck(DatabaseDeck initialCards, string ownerId)
        {
            /*
            List<DatabaseCard> cards = new List<DatabaseCard>();
            foreach (var item in initialCards.Cards)
            {
                DatabaseCard newCard = JsonConvert.DeserializeObject<DatabaseCard>((JsonConvert.SerializeObject(item)));
                cards.Add(newCard);
            }

            DatabaseDeck newDeck = new DatabaseDeck();
            ObjectId newObjectId = ObjectId.GenerateNewId();
            newDeck.id = newObjectId;
            newDeck.AuthorId = ownerId;
            newDeck.Cards = cards;
            */

            DatabaseDeck newDeck = initialCards;
            newDeck.DateCreated = DateTime.Now.ToString();
            ObjectId newObjectId = ObjectId.GenerateNewId();
            newDeck.id = newObjectId;

            IMongoCollection<DatabaseDeck> decks = database.GetCollection<DatabaseDeck>("Decks");
            await decks.InsertOneAsync(newDeck);

            return newObjectId;

        }

        public async Task registerUserDeck(ObjectId deckId, string ownerId)
        {
            IMongoCollection<DatabaseUser> users = database.GetCollection<DatabaseUser>("Users");
            var result = await users.FindAsync((user) => user.UserId.Equals(ownerId));
            var deckOwner = result.ToList().FirstOrDefault();

            var currentDecks = deckOwner.Decks;
            currentDecks.Add(deckId);
            deckOwner.Decks = currentDecks;

            DatabaseUser replacedUser = await users.FindOneAndReplaceAsync<DatabaseUser>((user) => user.UserId.Equals(ownerId), deckOwner);
            
        }

        /*
        public async Task<string> addCardToDeck(string deckId, DatabaseCard card)
        {
            IMongoCollection<DatabaseDeck> decks = database.GetCollection<DatabaseDeck>("Decks");
            IAsyncCursor<DatabaseDeck> findResult = await decks.FindAsync<DatabaseDeck>(deck => (deck.id.Equals(new ObjectId(deckId))));

            DatabaseDeck selectedDeck = findResult.ToList().FirstOrDefault();
            List<Card> deckList = selectedDeck.Cards;

            deckList.Add(card);

            DatabaseDeck newDeck = selectedDeck;
            newDeck.Cards = deckList;

            var replaceResult = await decks.ReplaceOneAsync(deck => deck.id.Equals(newDeck.id), newDeck);
            return replaceResult.ToString();

        }

        public async Task<string> removeFromDeck(string deckId, string cardId)
        {
            IMongoCollection<DatabaseDeck> decks = database.GetCollection<DatabaseDeck>("Decks");
            var result = await decks.FindAsync(deck => deck.id.Equals(new ObjectId(deckId)));
            DatabaseDeck selectedDeck = result.ToList().FirstOrDefault();

            List<Card> deckList = selectedDeck.Cards;
            
            for (int i = 0; i < deckList.Count; i++)
            {
                if (deckList[i].id.Equals(new ObjectId(cardId)))
                {
                    deckList.Remove(deckList[i]);
                }
            }

            DatabaseDeck newDeck = new DatabaseDeck();
            newDeck.id = new ObjectId(deckId);
            newDeck.Cards = deckList;

            ReplaceOneResult replaceOneResult = await decks.ReplaceOneAsync(deck => (deck.id.Equals(newDeck.id)), newDeck);
            return replaceOneResult.ToString();
        }
        */

        //-----------------------------Begin User Functions

        public async Task<ApiResponse> findUser(string id)
        {
            IMongoCollection<DatabaseUser> users = database.GetCollection<DatabaseUser>("Users");
            var result = await users.FindAsync<DatabaseUser>((user) => user.UserId.Equals(id));
            var resultsList = result.ToList();

            if (resultsList.Count == 0)
            {
                ApiResponse response = new ApiResponse();
                response.Successful = false;
                response.Message = "User not found";
                return response;
            }
            else
            {
                ApiResponse response = new ApiResponse();
                response.Successful = true;
                response.Data = resultsList.FirstOrDefault();
                return response;
            }
        }

        public async Task addUser(DatabaseUser user)
        {
            /*
            DatabaseUser newUser = new DatabaseUser();
            newUser.UserId = user.UserId;
            newUser.Email = user.Email;
            */

            DatabaseUser newUser = user;
            newUser.Decks = new List<ObjectId>();
            IMongoCollection<DatabaseUser> users = database.GetCollection<DatabaseUser>("Users");
            await users.InsertOneAsync(newUser);
        }
    }
}
