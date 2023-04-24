using Microsoft.AspNetCore.Mvc;
using Sinara.ApiService.Code;
using Sinara.UserService.TransortTypes.Api.Contracts;

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

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await DoRequest(async () => await _usersHttpApi.GetAllUsers());
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser()
        {
            return await DoRequest(async () => await _usersHttpApi.EditUser());
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser()
        {
            return await DoRequest(async () => await _usersHttpApi.DeleteUser());
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser()
        {
            return await DoRequest(async () => await _usersHttpApi.AddUser());
        }
    }
}
