using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicDatabaseApi.Models;
using MagicDatabaseApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json;

namespace MagicDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        CardService cardService = new CardService();
        private DbService service;

        public DeckController(DbService service)
        {
            this.service = service;
        }

        /*
        [HttpGet("addToDeck")]
        public async Task<string> addCardToDeck([FromQuery] string deckId, [FromQuery] string cardId)
        {
            try
            {
                DatabaseCard selectedCard = await service.queryCardById(cardId);
                string result = await service.addCardToDeck(deckId, selectedCard);
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet("removeFromDeck")]
        public async Task<string> removeFromDeck(string deckId, string cardId)
        {
            try
            {
                string message = await service.removeFromDeck(deckId, cardId);
                return message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        */

        [HttpGet("getDecks")]
        public async Task<string> getDecksByUser([FromQuery] string id)
        {
            try
            {
                List<ObjectId> ids = await service.getDecksByUser(id);
                List<DatabaseDeck> userDecks = new List<DatabaseDeck>();
                foreach (ObjectId item in ids)
                {
                    userDecks.Add(await service.getDeckById(item));
                }

                ApiResponse response = new ApiResponse();
                response.Successful = true;
                response.Data = userDecks;

                return JsonConvert.SerializeObject(response);
            }
            catch (Exception e)
            {
                ApiResponse response = new ApiResponse();
                response.Successful = false;
                response.Message = e.Message;
                return JsonConvert.SerializeObject(response);
            }

        }

        [HttpPost("createDeck")]
        public async Task<string> createDeck([FromBody] DatabaseDeck initialCards)
        {
            try
            {
                //List<object> deckList = initialCards.Cards;
                var deckId = await service.createDeck(initialCards, initialCards.AuthorId);
                await service.registerUserDeck(deckId, initialCards.AuthorId);
                return "Successfully created deck with ID: " + deckId.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }


}