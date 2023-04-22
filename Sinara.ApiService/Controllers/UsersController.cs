using Microsoft.AspNetCore.Mvc;
using Sinara.ApiService.Code;
using Sinara.UserService.TransortTypes.Api.Contracts;

namespace Sinara.ApiService.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUsersHttpApi _usersHttpApi;

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await DoRequest(async () => await _usersHttpApi.GetAllUsers());
        }

        [HttpGet("EditUser")]
        public async Task<IActionResult> EditUser()
        {
            return await DoRequest(async () => await _usersHttpApi.EditUser());
        }

        [HttpGet("DeleteUser")]
        public async Task<IActionResult> DeleteUser()
        {
            return await DoRequest(async () => await _usersHttpApi.DeleteUser());
        }

        [HttpGet("AddUser")]
        public async Task<IActionResult> AddUser()
        {
            return await DoRequest(async () => await _usersHttpApi.AddUser());
        }
    }
}
