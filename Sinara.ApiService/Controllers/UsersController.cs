using Microsoft.AspNetCore.Mvc;
using Sinara.ApiService.Code;
using Sinara.UserService.TransortTypes.Api.Contracts;
using Sinara.UserService.TransortTypes.Models.FormModels;

namespace Sinara.ApiService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUsersHttpApi _usersHttpApi;

        public UsersController(IUsersHttpApi usersHttpApi) 
        {
            _usersHttpApi = usersHttpApi;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(bool deleted = false)
        {
            return await DoRequest(async () => await _usersHttpApi.GetUsers(deleted));
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUserFormModel model)
        {
            return await DoRequest(async () => await _usersHttpApi.EditUser(model));
        }

        [HttpDelete("DeleteUser/{login}")]
        public async Task<IActionResult> DeleteUser(string login)
        {
            return await DoRequest(async () => await _usersHttpApi.DeleteUser(login));
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserFormModel model)
        {
            return await DoRequest(async () => await _usersHttpApi.AddUser(model));
        }
    }
}
