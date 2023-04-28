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

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(bool deleted = false)
        {
            return await DoRequest(async () => await _usersHttpApi.GetUsers(deleted));
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(string login, string firstName = null, string lastName = null, string fatherName = null, string newLogin = null)
        {
            return await DoRequest(async () => await _usersHttpApi.EditUser(login, firstName, lastName, fatherName, newLogin));
        }

        [HttpDelete("DeleteUser/{login}")]
        public async Task<IActionResult> DeleteUser(string login)
        {
            return await DoRequest(async () => await _usersHttpApi.DeleteUser(login));
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(string firstName, string lastName, string fatherName, string login)
        {
            return await DoRequest(async () => await _usersHttpApi.AddUser(firstName, lastName, fatherName, login));
        }
    }
}
