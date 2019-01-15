using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicDatabaseApi.Models;
using MagicDatabaseApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        readonly DbService dbService;

        public UsersController(DbService service)
        {
            this.dbService = service;
        }

        [HttpPost("add")]
        public async Task<ApiResponse> addUser([FromBody] DatabaseUser user)
        {
            try
            {
                ApiResponse found = await dbService.findUser(user.UserId);
                if (found.Successful)
                {
                    ApiResponse response = new ApiResponse();
                    response.Successful = true;
                    return response;
                }
                else
                {
                    await dbService.addUser(user);
                    ApiResponse response = new ApiResponse();
                    response.Successful = true;
                    return response;
                }
            }
            catch (Exception e)
            {
                ApiResponse response = new ApiResponse();
                response.Successful = false;
                response.Message = e.Message;
                return response;
            }
        }


    }
}