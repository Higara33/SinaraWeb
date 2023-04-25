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

        [HttpDelete("DeleteUser")]
        public async Task<ApiResult> DeleteUser(string login)
        {
            return await _usersHttpApi.DeleteUser(login);
        }

        [HttpPost("EditUser")]
        public async Task<ApiResult> EditUser(string login)
        {
            return await _usersHttpApi.EditUser(login);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ApiResult> GetAllUsers()
        {
            return await _usersHttpApi.GetAllUsers();
        }
    }
}
