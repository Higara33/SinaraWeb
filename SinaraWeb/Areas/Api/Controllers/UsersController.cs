using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Sinara.Core;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Api.Contracts;

namespace Sinara.UserService.Areas.Api.Controllers
{
    [ApiController]
    [Area(Constants.AreaMvc.Api)]
    [Route("/[area]/[controller]")]
    public class UsersController : Controller, IUsersHttpApi
    {
        private readonly IUsersHttpApi _usersHttpApi;

        public UsersController(IUsersHttpApi usersHttpApi) 
        {
            _usersHttpApi = usersHttpApi;
        }

        [HttpPost("AddUser")]
        public async Task<ApiResult> AddUser(string firstName, string lastName, string fatherName, string login)
        {
            return await _usersHttpApi.AddUser(firstName, lastName, fatherName, login);
        }

        [HttpDelete("DeleteUser/{login}")]
        public async Task<ApiResult> DeleteUser(string login)
        {
            return await _usersHttpApi.DeleteUser(login);
        }

        [HttpPost("EditUser")]
        public async Task<ApiResult> EditUser(string login, string firstName = null, string lastName = null, string fatherName = null, string newLogin = null)
        {
            return await _usersHttpApi.EditUser(login, firstName, lastName, fatherName, newLogin);
        }

        [HttpGet("GetUsers")]
        public async Task<ApiResult> GetUsers(bool deleted)
        {
            return await _usersHttpApi.GetUsers(deleted);
        }
    }
}
