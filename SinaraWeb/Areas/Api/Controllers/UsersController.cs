using Microsoft.AspNetCore.Mvc;
using Sinara.Core;
using Sinara.Core.Types.Api.ViewModels;
using Sinara.UserService.TransortTypes.Api.Contracts;
using SinaraWeb.DBConnect.Interfaces;
using SinaraWeb.DBConnect.Models;

namespace Sinara.UserService.Areas.Api.Controllers
{
    [ApiController]
    [Area(Constants.AreaMvc.Api)]
    [Route("/[area]/[controller]")]
    public class UsersController : Controller, IUsersHttpApi
    {
        private readonly IUsersHttpApi _usersHttpApi;

        [HttpPost("AddUser")]
        public async Task<ApiResult> AddUser()
        {
            return await _usersHttpApi.AddUser();
        }

        [HttpDelete("DeleteUser")]
        public async Task<ApiResult> DeleteUser()
        {
            return await _usersHttpApi.DeleteUser();
        }

        [HttpPost("EditUser")]
        public async Task<ApiResult> EditUser()
        {
            return await _usersHttpApi.EditUser();
        }

        [HttpGet("GetAllUsers")]
        public async Task<ApiResult> GetAllUsers()
        {
            return await _usersHttpApi.GetAllUsers();
        }
    }
}
