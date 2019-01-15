using MagicDatabaseApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using MagicDatabaseApi.Models;

namespace MagicDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private readonly DbService service;

        public DbController(DbService dbService)
        {
            this.service = dbService;
        }

        /*
        [HttpGet]
        public async Task<string> GetCards()
        {
            try
            {
                var queryResult = await service.QueryCards();
                string responseString = "{Data: " + JsonConvert.SerializeObject(queryResult) + "}";

                return responseString;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet("{name}")]
        public async Task<string> GetCardByName([FromRoute] string name, string type)
        {
            var queryResult = await service.QueryCardByName(name, type);
            if (queryResult.Data == null)
            {
                return "No results found.";
            }
            else
            {
                return JsonConvert.SerializeObject(queryResult);
            }
        }

        [HttpPost("add")]
        public async Task<string> AddCard([FromBody] Card cardData)
        {
            try
            {
                var card = await service.AddCard(cardData);

                var response = new ApiResponse();
                response.Data = card;
                response.Successful = true;

                return JsonConvert.SerializeObject(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse();
                response.Successful = false;
                response.Message = e.Message;
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpPost("Replace/{id}")]
        public async Task<string> replaceCard(string id, [FromBody] Card cardData)
        {
            try
            {
                var message = await service.ReplaceOneCard(id, cardData);
                return message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        */
    }
}
